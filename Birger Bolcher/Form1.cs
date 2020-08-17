using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Birger_Bolcher
{
    public partial class Form1 : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-24P629N\NOAHSQLSERVER;Initial Catalog=BirgerBolcher;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        //1. Udskriv alle informationer om alle bolcher.
        void FillDataGridViewAllBolcher()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.selectAllBolcher", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtvl = new DataTable();
            sqlDa.Fill(dtvl);
            dataGridView1.DataSource = dtvl;

            sqlCon.Close();
        }

        //2. Vis/udskriv navnene på alle de røde bolcher.
        void FillDataGridViewRedBolcherName()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.SelectAllRedBolcher", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtvl = new DataTable();
            sqlDa.Fill(dtvl);
            dataGridView1.DataSource = dtvl;

            sqlCon.Close();
        }

        //3. Vis/udskriv navnene på alle de røde og de blå bolcher, i samme SQL udtræk.
        void FillDataGridViewRedOrBlueBolcherName()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.SelectRedOrBlueBolcherName", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtvl = new DataTable();
            sqlDa.Fill(dtvl);
            dataGridView1.DataSource = dtvl;

            sqlCon.Close();
        }

        //4. Vis/udskriv navnene på alle bolcher, der ikke er røde, sorteret alfabetisk.
        void FillDataGridViewNotRedBolcherName()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.SelectAllBolcherButtNotRedBolcher", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtvl = new DataTable();
            sqlDa.Fill(dtvl);
            dataGridView1.DataSource = dtvl;

            sqlCon.Close();
        }

        //5. Vis/udskriv navnene på alle bolcher som starter med et “B”.
        void FillDataGridViewAllBolcherNameStratsWithB()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.SelectAllBolcherThatStartsWithB", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtvl = new DataTable();
            sqlDa.Fill(dtvl);
            dataGridView1.DataSource = dtvl;

            sqlCon.Close();
        }
        //6. Vis/udskriv navnene på alle bolcher, hvor der i navnet findes mindst ét “e”
        void FillDataGridViewAllBolcherNameThatContensAE()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.SelectAllBolcherWereAEExsist", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtvl = new DataTable();
            sqlDa.Fill(dtvl);
            dataGridView1.DataSource = dtvl;

            sqlCon.Close();
        }

        //7. Vis/udskriv navn og vægt på alle bolcher der vejer mindre end 10 gram, 
        //sorter dem efter vægt, stigende.

        void FillDataGridViewAllBolcherNameThatWighLesThenTenGrams()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.SelectAllBolcherWightLesTheTenGrams", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtvl = new DataTable();
            sqlDa.Fill(dtvl);
            dataGridView1.DataSource = dtvl;

            sqlCon.Close();
        }

        //8. Vis/udskriv navnene på alle bolcher, der vejer mellem 10 og 12 gram  
        //(begge tal inklusive), sorteret alfabetisk og derefter vægt.
        void FillDataGridViewAllBolcherNameThatWighBetweenTenAndTwelveGrams()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.SelectAllBolcherWereTheWightIsBetweenTenAndTwelveGrams", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtvl = new DataTable();
            sqlDa.Fill(dtvl);
            dataGridView1.DataSource = dtvl;

            sqlCon.Close();
        }

        //9. Vælg de tre største (tungeste) bolcher.
        void FillDataGridViewAllBolcherNameToptreBolcherByWight()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.SelectToptreBolcherByWight", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtvl = new DataTable();
            sqlDa.Fill(dtvl);
            dataGridView1.DataSource = dtvl;

            sqlCon.Close();
        }

        //10. Udskriv alle informationer om et søgt bolche(via søgning)
        void FillDataGridViewAllBolcherNameBySearch()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.NameSearch", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@BolcheName", textBox1.Text.Trim());
            DataTable dtvl = new DataTable();
            sqlDa.Fill(dtvl);
            dataGridView1.DataSource = dtvl;

            sqlCon.Close();
        }

        //1. Udskriv alle informationer om alle bolcher.
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridViewAllBolcher();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }
        }

        //2. Vis/udskriv navnene på alle de røde bolcher.
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridViewRedBolcherName();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }
        }
        //3. Vis/udskriv navnene på alle de røde og de blå bolcher, i samme SQL udtræk.
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridViewRedOrBlueBolcherName();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }
        }

        //4. Vis/udskriv navnene på alle bolcher, der ikke er røde, sorteret alfabetisk.
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridViewNotRedBolcherName();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }
        }

        //5. Vis/udskriv navnene på alle bolcher som starter med et “B”.
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridViewAllBolcherNameStratsWithB();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }
        }

        //6. Vis/udskriv navnene på alle bolcher, hvor der i navnet findes mindst ét “e”
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridViewAllBolcherNameThatContensAE();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }
        }

        //7. Vis/udskriv navn og vægt på alle bolcher der vejer mindre end 10 gram, 
        //sorter dem efter vægt, stigende.
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridViewAllBolcherNameThatWighLesThenTenGrams();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }
        }

        //8. Vis/udskriv navnene på alle bolcher, der vejer mellem 10 og 12 gram  
        //(begge tal inklusive), sorteret alfabetisk og derefter vægt.
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridViewAllBolcherNameThatWighBetweenTenAndTwelveGrams();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }
        }

        //9. Vælg de tre største (tungeste) bolcher.
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridViewAllBolcherNameToptreBolcherByWight();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }
        }

        //10. Udskriv alle informationer om et tilfældigt bolche, udvalgt af systemet. (via søgning)
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridViewAllBolcherNameBySearch();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

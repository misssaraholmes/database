using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace database
{


    public partial class Form1 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Lenovo\\source\\repos\\database\\database\\StudentDatabase11.accdb";
        private OleDbConnection con;

        public Form1()
        {
            con = new OleDbConnection(connectionString);
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            UpdataStudentGrid();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string StudentNO = txtStudentNo.Text;
            string Studentfirstname = txtFirstName.Text;
            string Studentlastname = txtLastName.Text;

            string insertCommand = $"Insert Into Student(Studentfirstname,Studentlastname,StudentNO)" + $"value('{txtFirstName.Text}','{txtLastName.Text}','{txtStudentNo.Text}')";
            OleDbCommand command = new OleDbCommand(insertCommand, con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            UpdataStudentGrid();
        }
        private void UpdataStudentGrid()

        {
            string selectCommand = "Select * from Student";
            OleDbCommand command = new OleDbCommand(selectCommand, con);
            con.Open();
            OleDbDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            con.Close();
            dataGridView1.DataSource = dt;
        }
    }
   
    
    
}
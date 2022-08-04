using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace SQL_SERVER_CRUD_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=JARVIS\SQLSERVER1;Initial Catalog=EmployeeDB;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into Table1 (Id,Name,Age) values (@Id,@Name,@Age) ", connection);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=JARVIS\SQLSERVER1;Initial Catalog=EmployeeDB;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update Table1 set Name=@Name, Age=@Age where Id=@Id", connection);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=JARVIS\SQLSERVER1;Initial Catalog=EmployeeDB;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete Table1 where Id=@Id", connection);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=JARVIS\SQLSERVER1;Initial Catalog=EmployeeDB;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * from Table1 where Id=@Id", connection);
            cmd.Parameters.AddWithValue("Id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}

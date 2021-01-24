    using System.Data.SqlClient;
    namespace test
    {
    public partial class Form1 : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }
      
    private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection (@"Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
            sda = new SqlDataAdapter(@"SELECT* FROM dbo.MyTable", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt; 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
            MessageBox.Show("Table updated");
        }
    }

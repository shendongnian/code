    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = GetData();
        }
        public DataTable GetData()
        {
            string ConStr = " your connection string ";  // Write here your connection string
            string query = @"SELECT * FROM Customer";   // or write your specific query
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(ConStr);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = null;
            try
            {
                conn.Open();
                // create data adapter
                da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot read database: {ex.Message}");
            }
            finally
            {
                conn.Close();
                if (da != null)
                    da.Dispose();
            }
            return dataTable;
        }
        public void FillDataGrid()
        {
            Connection2DB cst = new Connection2DB();
            dataGridView1.DataSource = cst.GetData();
        }
    }

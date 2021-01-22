    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        private delegate DataSet GetDSDelegate(string query);
    
        private void button1_Click(object sender, EventArgs e)
        {
            GetDSDelegate del = new GetDSDelegate(GetDataSetAsync);
            del.BeginInvoke(@"Select top 3 * from table1;", null, null);
        }
    
        private DataSet GetDataSetAsync(string query)
        {
            DataSet ds;
            using (SqlConnection conn = new SqlConnection(@"Data Source = mmmmm000011\sqlexpress; Initial Catalog = SOExamples; Integrated Security = SSPI; Asynchronous Processing = true;"))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
    
                    DataTable dt = new DataTable();
                    ds = new DataSet();
    
                    dt.Load(dr);
                    ds.Tables.Add(dt);
                    dr.Close();
                    Complete(ds);
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
            MessageBox.Show("Done!!!");
            return ds;
        }
    
        private void Complete(DataSet ds)
        {
            ...
        }
    }

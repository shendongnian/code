    C#
    //Set the Page Size.
    int PageSize = 5;
    private void Form1_Load(object sender, EventArgs e)
    {
        this.BindGrid(1);
    }
     
    private void BindGrid(int pageIndex)
    {
        string constring = @"Data Source=.\SQL2005;Initial Catalog=Northwind;Integrated Security=true";
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("GetCustomersPageWise", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                cmd.Parameters.AddWithValue("@PageSize", PageSize);
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dt;
                con.Close();
                int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                this.PopulatePager(recordCount, pageIndex);
            }
        }
    }
     

    using (SqlConnection conn = new SqlConnection("your connection string"))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM Authors", conn))
        {
            using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }

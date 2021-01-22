    using (SqlConnection conn = new SqlConnection("..."))
    using (SqlCommand cmd = new SqlCommand(@" SELECT * FROM Authors", conn))
    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
    {
        conn.Open();
        DataTable dt = new DataTable();
        dataGridView1.DataSource = dt;
    }

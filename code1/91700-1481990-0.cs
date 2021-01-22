    using (SqlConnection conn = new SqlConnection("your connection string"))
    {
        conn.Open();
        using (SqlCommand cmd = 
            new SqlCommand("SELECT ID, FullName FROM tblPeople", conn))
        {
            using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                comboBox1.DisplayMember = "FullName";
                comboBox1.ValueMember = "ID";
                comboBox1.DataSource = dt;
            }
        }
    }

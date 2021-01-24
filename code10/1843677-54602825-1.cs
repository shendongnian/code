    DataTable dt = new DataTable();
    string error;
    using (SqlConnection con = new SqlConnection(@"Data Source=SERVER;Initial Catalog=DATEBASE; User ID=USERNAME; Password=PASSWORD"))
    {
        SqlCommand cmd = new SqlCommand();
        foreach (DataGridViewRow row in dgvAtt.Rows)
        {
            string Query = "SELECT Signature FROM TBL_Student WHERE Name = '";
            if (row.Cells.Count >= 4 && row.Cells[4].Value != null)
            {
                Query += row.Cells[4].Value.ToString();
            }
            Query += "'";
            try
            {
                cmd = new SqlCommand(Query, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }
    }
    dgvSign.DataSource = dt;

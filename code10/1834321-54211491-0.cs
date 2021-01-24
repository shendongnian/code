    string sql = "SELECT * FROM t";
 
    using (SqlConnection con = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand(sql, con))
    {
        SqlDataReader reader;
        con.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            // TODO: consume data
        }
        reader.Close();
    }

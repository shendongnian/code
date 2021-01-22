    using (SqlConnection conn = new SqlConnection(connStr))
    using (SqlCommand cmdRead = new SqlCommand("select stools from foo", conn))
    {
        conn.Open();  
        using (SqlDataReader rdr = cmdRead.ExecuteReader())
        {
            while(rdr.Read()) 
            {
                int stools = rdr.GetInt32(0);
            }
        }
    }

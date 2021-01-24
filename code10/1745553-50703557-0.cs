    SqlCommand cmd = new SqlCommand();
    using (SqlDataReader rdr = cmdCount.ExecuteReader())
    {
        while (rdr.Read())
        {
            string text1 = rdr.GetString(0);
            string text2 = rdr.GetString(1);
        }
    }

    SqlCommand comm = new SqlCommand("SELECT * FROM Products", connection);
    using (SqlDataReader reader = comm.ExecuteReader())
    {
        while (reader.Read())
        {
            Type type = reader.GetSqlValue(0).GetType();
            // OR Type type = reader.GetSqlValue("name").GetType();
            // yields type "System.Data.SqlTypes.SqlInt32"
        }
    }

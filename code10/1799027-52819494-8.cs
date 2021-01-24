    using (var sqlConnection = DatabaseUtil.DatabaseUtil.CreateSqlConnection())
    using (var cmd = new SqlCommand(query, sqlConnection))
    {
        //add parameter to cmd.Parameters collection here
       
        using (var reader = cmd.ExecuteReader())
        {
            while(reader.Read()
            {
                //some code here
            }
        }
    }

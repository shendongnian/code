    using (var sqlConnection = DatabaseUtil.DatabaseUtil.CreateSqlConnection(connectionString)){
    using (var cmd = new SqlCommand(query, sqlConnection))
    using (var reader = cmd.ExecuteReader())
    {
        while(reader.Read()
        {
            //some code here
        }
    }

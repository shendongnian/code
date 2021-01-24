    var parameters = new SqlParameter[] { }; //define parameters here
    using (var sqlConnection = DatabaseUtil.DatabaseUtil.CreateSqlConnection())
    using (var cmd = DatabaseUtil.DatabaseUtil.InitializeSqlCommand(sqlConnection, query, parameters))
    using (var reader = cmd.ExecuteReader())
    {
        while(reader.Read()
        {
            //some code here
        }
    }

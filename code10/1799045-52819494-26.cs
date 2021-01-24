    var parameters = new SqlParameter[] { }; //define parameters here
    using (var sqlConnection = DatabaseUtil.CreateSqlConnection())
    using (var cmd = DatabaseUtil.InitializeSqlCommand(sqlConnection, query, parameters))
    using (var reader = cmd.ExecuteReader())
    {
        while(reader.Read())
        {
            //some code here
        }
    }

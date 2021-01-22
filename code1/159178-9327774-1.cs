    using (new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 0, 0, 1)))
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var sqlCommand = connection.CreateCommand())
            {
                for (int i = 0; i < 10000; i++)
                {
                    sqlCommand.CommandText = "select * from actor";
                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                        }
                    }
                }
            }
        }
    }

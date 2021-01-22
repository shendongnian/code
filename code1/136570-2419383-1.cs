     public static DataTable GetDataTable(string sql)
            {
                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = connectionString;
    
                    using (DbCommand command = factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = sql;
    
                        using (DbDataAdapter adapter = factory.CreateDataAdapter())
                        {
                            adapter.SelectCommand = command;
    
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
    
                            return dt;
                        }
                    }
                }

    DataTable table;
    using (SqlDbConnection connection = new SqlDbConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDbCommand command = new SqlDbCommand(tableName, connection))
                    {
                        command.CommandType = CommandType.TableDirect;
                        SqlDbDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                        table = new DataTable(tableName);
                        routeID.Load(dr);
                    }
                 }

    public static class DB {
    private static readonly string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
    private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
    
    public static int Update(string sql)
            {
                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = connectionString;
    
                    using (DbCommand command = factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = sql;
    
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                }
            }
    
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
    }

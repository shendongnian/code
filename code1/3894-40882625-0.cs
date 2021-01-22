    public void Demo()
            {
                NpgsqlConnection connection = new NpgsqlConnection();
                connection = d_connection; // your connection string
                connection.Open();              
                NpgsqlCommand cmd = new NpgsqlCommand();
                try
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from your table name";
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            
                         string answer= dataReader.IsDBNull(0) ? "" : dataReader.GetString(0);
                            
                        }
                        dataReader.Dispose();
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    cmd.Dispose();
                    connection.Dispose();
                }            
            }

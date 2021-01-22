    public static bool ExecuteBulkNonQuery<T>(string connectionString, CommandType commandType, 
                string commandText, IEnumerable<T> listItems, Func<T,SqlParameter[]> setParameters)
            {
                var fails = 0;
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var comm = new SqlCommand(commandText, conn))
                    {
                        comm.CommandType = commandType;
                        conn.Open();
                        foreach (var obj in listItems)
                        {
                            comm.Parameters.Clear();
                            comm.Parameters.AddRange(setParameters.Invoke(obj));
                            fails += comm.ExecuteNonQuery();
                        }
                        return fails != 0;
                    }
                }
            }

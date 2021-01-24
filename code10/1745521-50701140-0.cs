			var conn = DbContext.Database.GetDbConnection();
            try
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    string query = $"select * from .......";
                    command.CommandText = query;
                    DbDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //read line to line							
                        }
                    }
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }

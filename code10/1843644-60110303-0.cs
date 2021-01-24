        public void ExecuteNonQuery(string query, string connectionString)
        {
            string[] splitter = new string[] {"\r\nGO"};
            string[] commandTexts = query.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.RetryOpen();
                foreach (var commandText in commandTexts)
                {
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = commandText;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }
                }
                connection.Close();
            }
        }

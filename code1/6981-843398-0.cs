        private static void CreateCommand(string queryString,string connectionString)
        {
            int maxRetries = 3;
            int retries = 0;
            while(true)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                    break;
                }
                catch (SqlException se)
                {
                    if (se.Message.IndexOf("Timeout", StringComparison.InvariantCultureIgnoreCase) == -1)
                        throw; //not a timeout
                    if (retries >= maxRetries)
                        throw new Exception( String.Format("Timedout {0} Times", retries),se);
                    //or break to throw no error
                    retries++;
                }
            }
        }

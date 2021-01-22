    public static bool CheckDatabaseExists(string connectionString, string databaseName)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(string.Format("SELECT db_id('{0}')", databaseName), connection))
                    {
                        connection.Open();
                        return (command.ExecuteScalar() != DBNull.Value);
                    }
                }
            }

    public static bool CheckDatabaseExists(string connectionString, string databaseName)
    {
          using (var connection = new SqlConnection(connectionString))
          {
               using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection))
               {
                    connection.Open();
                    return (command.ExecuteScalar() != DBNull.Value);
               }
          }
    }

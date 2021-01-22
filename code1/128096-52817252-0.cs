    public static async Task<bool> TestDatabase(string connectionString, string databaseName)
    {
       using (var connection = new SqlConnection(connectionString))
       using (var command = new SqlCommand("SELECT db_id(@databaseName)", connection))
       {
           command.Parameters.Add(new SqlParameter("databaseName", databaseName));
           connection.Open();
           return (await command.ExecuteScalarAsync() != DBNull.Value);
       }
    }

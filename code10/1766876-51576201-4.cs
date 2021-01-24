    using Microsoft.Data.Sqlite;
    
    class Program
    {
        static void Main()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();
    
            var createCommand = connection.CreateCommand();
            createCommand.CommandText =
            @"
                CREATE TABLE data (
                    value TEXT
                )
            ";
    
            createCommand.ExecuteNonQuery();
        }
    }

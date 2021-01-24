    public class DatabaseConnectionString : IDatabaseConnectionString
    {
        public string ConnectionString { get; }
    
        public DatabaseConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }

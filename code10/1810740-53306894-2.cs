    public class ConnectionManager
    {
        private string _connectionString;
        public ConnectionManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

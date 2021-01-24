    public class ConnectionStringFactory : IConnectionStringFactory
    {
        private readonly string _connectionString;
        public ConnectionStringFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public string Invoke()
        {
            return _connectionString;
        }
    }

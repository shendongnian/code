    public class DataAccess
    {
        private string _connectionString;
        public DataAccess()
        {
            var config = new ConfigurationService();
            _connectionString = config.ConnectionString;
        }
    }

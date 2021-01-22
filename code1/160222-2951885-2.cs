    public class DataAccess
    {
        private string _connectionString;
        public DataAccess(IConfigurationService configurationService)
        {
            _connectionString = configurationService.ConnectionString;
        }
    }

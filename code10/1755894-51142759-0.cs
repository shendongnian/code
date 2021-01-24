    public class SqlSettingsProvider : ISettingsProvider
    {
        private readonly string _connectionString;
        public SqlSettingsProvider(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Settings GetSettings()
        {
            // load the settings from SQL
        }
    }

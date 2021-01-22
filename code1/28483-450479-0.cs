    class SmartDbConnection
    {
        private DbConnection Connection;
        public SmartDbConnection(string provider, string connectionString)
        {
            Connection = DbProviderFactories.GetFactory(provider)
                .CreateConnection();
            Connection.ConnectionString = connectionString;
        }
        public void Dispose() {
            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }
        }
    }

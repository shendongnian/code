    public static class FactoryExtensions
    {
        public static DbParameter GetParameter(this DbProviderFactory factory, string name, object value)
        {
            var param = factory.CreateParameter();
            param.Value = value ?? DBNull.Value;
            return param;
        }
        public static DbConnection CreateConnection(this DbProviderFactory factory, string connectionString, bool open = true)
        {
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            if (open)
                connection.Open();
            return connection;
        }
    }

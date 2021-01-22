    class SmartDbConnection<T> where T : IDbConnection, new()
    {
        private readonly IDbConnection Connection;
        public SmartDbConnection(string connectionString)
        {
            if (connectionString.Contains("MultipleActiveResultSets=true"))
            {
                Connection = new T();
                Connection.ConnectionString = connectionString;
            }
        }
    }

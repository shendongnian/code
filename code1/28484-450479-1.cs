    class SmartDbConnection<T> : IDisposable where T : class,
        IDbConnection, new()
    {
        private T Connection;
        public SmartDbConnection(string connectionString)
        {
            T t = new T();
            t.ConnectionString = connectionString;
            // etc
        }
        public void Dispose() {
            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }
        }
    }

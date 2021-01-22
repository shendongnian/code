    public class YourClass : IDisposable
    {
        private IDbConnection connection;
        private IDataReader reader;
    
        public IDataReader Reader { get { return reader; } }
    
        public YourClass(IDbConnection connection, IDataReader reader)
        {
            this.connection = connection;
            this.reader = reader;
        }
    
        public void Dispose()
        {
            reader.Dispose();
            connection.Dispose();
        }
    }

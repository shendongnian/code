    public class Repository
    {
        private IDbConnection connection;
        public Repository(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            this.connection = connection;
        }
    }

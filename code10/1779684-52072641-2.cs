    public class DbFactory : IDbFactory
    { 
        public DbContext GetConnection()
        {
            var connectionString = [get this from web.config]
            return new DbContext.Create(connectionString);
        }
    }

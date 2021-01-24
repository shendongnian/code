    public class MyDbConnectionFactory : IDbConnectionFactory {
        private readonly IAppSettings appSettings;
    
        public UnitOfWork(IAppSettings appSettings) {
            this.appSettings = appSettings;
        }
    
        public IDbConnection CreateConnection() {
            return new SqlConnection(appSettings.GetConnectionString());
        }
    }

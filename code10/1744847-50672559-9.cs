    public class MyDbConnectionFactory : IDbConnectionFactory {
        private readonly IAppSettings appSettings;
    
        public MyDbConnectionFactory(IAppSettings appSettings) {
            this.appSettings = appSettings;
        }
    
        public IDbConnection CreateConnection() {
            return new SqlConnection(appSettings.GetConnectionString());
        }
    }

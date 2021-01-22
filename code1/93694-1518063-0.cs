    public class DatabaseBase
    {
        private readonly string connectionString;
        private bool useCounters;
        public DatabaseBase(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public string ConnectionString
        {
            get { return connectionString; }
        }
    }
    public class ProjectDB : DatabaseBase
    {
        private bool useWebServiceConnection;
        private bool isWebServiceCall;
        public ProjectDB(bool useWebServiceConnection)
            : base(
                useWebServiceConnection
                    ? ConfigurationManager.AppSettings["ServiceConnectionString"]
                    : ConfigurationManager.AppSettings["SomeOtherConnectionString"])
        {
            this.useWebServiceConnection = useWebServiceConnection;
        }
        private SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }

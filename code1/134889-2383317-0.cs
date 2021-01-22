        public static class DataConnection
    {
    #if LOCALDEV
        public const string Env = "Debug";
    #endif
    #if STAGING
        public const string Env="Staging";
    #endif
    #if RELEASE
        public const string Env="Release";
    #endif
        private static ConnectionStringSettingsCollection _connections;
        static DataConnection()
        {
            _connections = ConfigurationManager.ConnectionStrings;
        }
        public static string BoloConnectionString
        {
            get
            {
                return _connections["DB1."+Env].ConnectionString;
            }
        }
        public static string AOAConnectionString
        {
            get
            {
                return _connections["DB2."+Env].ConnectionString;
            }
        }
        public static string DocVueConnectionString
        {
            get
            {
                return _connections["DB3."+Env].ConnectionString;
            }
        }
    }

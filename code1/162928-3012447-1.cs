        public static string DefaultDatabase
        {
            get
            {
                SystemConfigurationSource scs = new SystemConfigurationSource();
                return DatabaseSettings.GetDatabaseSettings(scs).DefaultDatabase;
            }
        }
        public static string DefaultConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[Sql.DefaultDatabase].ConnectionString;
            }
        }

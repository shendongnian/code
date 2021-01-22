    public ISessionFactory BuildSessionFactory(string connectionString) {
    	var cfg = new Configuration()
                    .AddProperties(new Dictionary<string, string> {
                        {Environment.ConnectionDriver, typeof (SQLite20Driver).FullName},
                        {Environment.ProxyFactoryFactoryClass, typeof (ProxyFactoryFactory).AssemblyQualifiedName},
                        {Environment.Dialect, typeof (SQLiteDialect).FullName},
                        {Environment.ConnectionProvider, typeof (DriverConnectionProvider).FullName},
                        {Environment.ConnectionString, connectionString},
                    })
                    .AddAssembly(Assembly.GetExecutingAssembly());
    	return cfg.BuildSessionFactory();
    }

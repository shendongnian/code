    private ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure()
            .Database(
                IfxOdbcConfiguration
                    .Informix1000
                    .ConnectionString("Provider=Ifxoledbc.2;Password=mypass;Persist Security Info=True;User ID=myid;Data Source=mysource")
                    .Driver<OleDbDriver>()
                    .Dialect<InformixDialect1000>()
                    .ProxyFactoryFactory<ProxyFactoryFactory>()
            )
            .Mappings(
                m => m
                    .FluentMappings
                    .AddFromAssemblyOf<SomePersistentType>()
            )
            .BuildSessionFactory();
    }

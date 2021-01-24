    public ISession OpenSession()
    {
            ISessionFactory sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SP_Quarters>().Add<SP_QuartersMap>())
                  .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
            .BuildSessionFactory();
        return sessionFactory.OpenSession();
    }

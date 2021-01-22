    private static ISession CreateSession()
    {
        if (_sessionFactory == null)
        {
            _sessionFactory = Fluently.Configure().
                Database(SQLiteConfiguration.Standard.ShowSql().UsingFile("test.db")).
                Mappings(m => m.FluentMappings.AddFromAssemblyOf<MappingsPersistenceModel>()).
                BuildSessionFactory();
        }
        return _sessionFactory.OpenSession();
    }

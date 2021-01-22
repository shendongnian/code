    static readonly object factorylock = new object();
    public ISession OpenSession()
    {
        lock (factorylock)
        {
           if (_sessionFactory == null)
           {
                var cfg = Fluently.Configure().
                   Database(SQLiteConfiguration.Standard.ShowSql().UsingFile("Foo.db")).
                   Mappings(m => m.FluentMappings.AddFromAssemblyOf<MappingsPersistenceModel>());
                _sessionFactory = cfg.BuildSessionFactory();
                BuildSchema(cfg);
            }
        }
        return _sessionFactory.OpenSession();
    }

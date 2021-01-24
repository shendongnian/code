    static NHibernateHelper()
    {            
        _sessionFactory = 
            Fluently.Configure()
            // ...
                .Mappings(
                    c => 
                        c.FluentMappings
                            .AddFromAssemblyOf<Company>()
                            .AddFromAssemblyOf<BDICode>())
                .BuildSessionFactory();
    }

     var sessionFactory = Fluently.Configure()  
       .Database(MsSqlConfiguration.MsSql2005  
         .ConnectionString(c => c  
           .Is(ApplicationConnectionString)))  
       .Mappings(m =>  
         m.AutoMappings.Add(AutoPersistenceModel.MapEntitiesFromAssemblyOf<Product>())  
       )  
       .BuildSessionFactory();

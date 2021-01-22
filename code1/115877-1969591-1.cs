    var autoMappings = AutoPersistenceModel  
      .MapEntitiesFromAssemblyOf<Product>()  
      .Where(t => t.Namespace == "Storefront.Entities");  
  
    var sessionFactory = new Configuration()  
      .AddProperty(ConnectionString, ApplicationConnectionString)  
      .AddAutoMappings(autoMappings)  
      .BuildSessionFactory();  

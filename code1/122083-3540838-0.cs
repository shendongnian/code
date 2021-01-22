    ISessionFactory session = Fluently.Configure()
        .Database(SQLiteConfiguration.Standard.InMemory())
        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MessagingDescriptorMap>())
    
        .ExposeConfiguration(c =>
        {
            config = c; //pass configuration to class scoped variable
        })
        .BuildSessionFactory();

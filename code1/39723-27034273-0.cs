    `SessionFactory = Fluently.Configure()
    .Database(MySQLConfiguration.Standard
    .ConnectionString(connectionString))
    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
    .BuildSessionFactory();`

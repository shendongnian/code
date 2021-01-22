    return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                     c =>
                       c.FromConnectionStringWithKey("DisillStoreConnectionString")))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())) 
                    .BuildSessionFactory();

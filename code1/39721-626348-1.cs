    Fluently.Configure().Database(
            MySQLConfiguration.Standard.ConnectionString(
                c => c.FromConnectionStringWithKey("ConnectionString")
            )
        )
        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MyAutofacModule>())
        .BuildSessionFactory())

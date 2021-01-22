    sessionFactory = Fluently.Configure()
        .Database(
            MsSqlConfiguration.MsSql2005.ConnectionString(p =>
                p.FromConnectionStringWithKey("QoiSqlConnection")))
        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<JobMapping>())
        .ExposeConfiguration(x => x.SetProperty("current_session_context_class", "web")
        .BuildSessionFactory();

    public static void BuildFactory()
    {
        _factory = Fluently.Configure()
            .Database(
                MsSqlConfiguration
                    .MsSql2008
                    .ConnectionString(_connectionString)
                    .ShowSql()
            )
            .Mappings(m => {
                m.FluentMappings.AddFromAssemblyOf<Database>();
                m.AutoMappings.Add(
                  AutoMap.AssemblyOf<Database>()
                  .Where(t => t.Namespace == "FancyStore.Models.Catalog"));
            })
            .ExposeConfiguration(SetConfiguration)
            .BuildConfiguration()
            .BuildSessionFactory();
    }

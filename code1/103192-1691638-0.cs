    // part of a default abstract setup class I use
    public ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure()
            .Database(
                MsSqlConfiguration.MsSql2008
                    .ConnectionString(c =>
                        c.Server(this.ServerName)
                        .Database(this.DatabaseName)
                        .Username(this.Username)
                        .Password(this.Password)
                        )
            )
            .Mappings(m =>
                m.AutoMappings.Add(AutoMap.AssemblyOf<Setup>()
                    .Where(t => t.Namespace == this.Namespace))
                    // here go the associations and constraints,
                    // (or you can annotate them, or add them later)
                )
            .ExposeConfiguration(CreateOrUpdateSchema)
            .BuildSessionFactory();
    }

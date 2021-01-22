    private ISessionFactory createSessionFactory()
    {
        return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFileWithPassword(filename, password))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DBManager>())
                .ExposeConfiguration(this.buildSchema)
                .BuildSessionFactory();    
    }
    private void buildSchema(Configuration config)
    {
            if (filename_not_exists == true)
            {
                new SchemaExport(config).Create(false, true);
            }
    }    

    using (var db = new MyDbContext())
    {
        var reporter = new OperationReporter(handler: null);
        var designTimeServiceCollection = new ServiceCollection()
            .AddSingleton<IOperationReporter>(reporter)
            .AddScaffolding(reporter);
        new SqlServerDesignTimeServices().ConfigureDesignTimeServices(designTimeServiceCollection);
        var designTimeServices = designTimeServiceCollection.BuildServiceProvider();
        var databaseModelFactory = designTimeServices.GetService<IScaffoldingModelFactory>();
        var databaseModel = (Model)databaseModelFactory.Create(
            db.Database.GetDbConnection().ConnectionString,
            tables: new string[0],
            schemas: new string[0],
            useDatabaseNames: false);
        var currentModel = db.Model;
        // Fix up the database model. It was never intended to be used like this. ;-)
        foreach (var entityType in databaseModel.GetEntityTypes())
        {
            if (entityType.Relational().Schema == databaseModel.Relational().DefaultSchema)
            {
                entityType.Relational().Schema = null;
            }
        }
        databaseModel.Relational().DefaultSchema = null;
        databaseModel.SqlServer().ValueGenerationStrategy =
            currentModel.SqlServer().ValueGenerationStrategy;
        // TODO: ...more fix up as needed
        var differ = db.GetService<IMigrationsModelDiffer>();
        
        if (differ.HasDifferences(databaseModel, currentModel))
        {
            throw new Exception("The database and model are out-of-sync!");
        }
    }

    var configuration = new DbMigrationsConfiguration
    {
    	ContextType = typeof(ApplicationDbContext),
    	MigrationsAssembly = typeof(ApplicationDbContext).Assembly,
    	MigrationsNamespace = "YourNamespace.Migrations",
    	AutomaticMigrationsEnabled = true
    };
    var dbMigrator = new DbMigrator(configuration);
    var migratorScriptingDecorator = new MigratorScriptingDecorator(dbMigrator);
    string script = migratorScriptingDecorator.ScriptUpdate(sourceMigration: null, targetMigration: null);

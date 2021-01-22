    public static void MigrateToLastVersion(string provider, string connectionString)
    {
        var silentLogger = new Logger(false, new ILogWriter[0]);
        var migrator = new Migrator.Migrator(provider, connectionString, 
                       typeof(YourMigrationAssembly).Assembly, false, silentLogger);
        migrator.MigrateToLastVersion();
    }

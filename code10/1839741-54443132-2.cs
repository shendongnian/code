    var upgrader = debug 
                ? DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .WithReadOnlyJournal("dbo", "SchemaVersions")
                    .LogToConsole()
                    .Build()
                : DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();
    var result = upgrader.PerformUpgrade();
            if (!result.Successful)
            ....

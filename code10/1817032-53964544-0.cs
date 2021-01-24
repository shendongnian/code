    var database = new ApplicationDbContext().Database;
            var configuration = new DbMigrationsConfiguration
            {
                TargetDatabase =
                                            new DbConnectionInfo(
                                                database.Connection.ConnectionString,
                                                "System.Data.SqlClient"),
                ContextType = typeof(ApplicationDbContext),
                MigrationsAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext)),
                MigrationsNamespace = "Prom.Database.Migrations",
                ContextKey = "Prom.Database.Migrations.Configuration"
            };

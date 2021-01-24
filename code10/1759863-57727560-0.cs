      services.AddScoped<IDbConnection, OracleConnection>();
            services.AddScoped<IDbConnection, SqlConnection>();
            services.Configure<DatabaseConnections>(configuration.GetSection("DatabaseConnections"));
            services.AddScoped(resolver =>
            {
                var databaseConnections = resolver.GetService<IOptions<DatabaseConnections>>().Value;
                var iDbConnections = resolver.GetServices<IDbConnection>();
                databaseConnections.OracleConnections.ToList().ForEach(ora =>
                {
                    ora.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(OracleConnection)).FirstOrDefault();
                    ora.dbConnection.ConnectionString = ora.ConnectionString;
                    //ora.Guid = Guid.NewGuid();
                });
                databaseConnections.MSSqlConnections.ToList().ForEach(sql =>
                {
                    sql.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(SqlConnection)).FirstOrDefault();
                    sql.dbConnection.ConnectionString = sql.ConnectionString;
                    //sql.Guid = Guid.NewGuid();
                });
                return databaseConnections;
            });

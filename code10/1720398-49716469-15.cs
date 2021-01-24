    var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            // Add "appsettings.json" to bootstrap EF config.
            .AddJsonFile("appsettings.json")
            // Add the EF configuration provider, which will override any
            // config made with the JSON provider.
            .AddCustomMailConfigProvider(dbOptions =>
                dbOptions .UseSqlServer(connectionStringConfig.GetConnectionString(
                    "DefaultConnection"))
            )
            .Build();

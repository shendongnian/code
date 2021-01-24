            string basePath = "";
            try
            {
                var env = PlatformServices.Default.Application;
                basePath = Directory.GetCurrentDirectory();
                var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
                Configuration = builder.Build();
                return Configuration.GetConnectionString(connectionStringName);
            }
            catch (Exception ex)
            {
            }
        }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationRoot Configuration = null;
            string basePath = Directory.GetCurrentDirectory();
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
               .AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
        }

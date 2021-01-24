         public IConfiguration Configuration { get; private set; }
    
         private void ConfigureSettings()
            {
                Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appSettings.json", optional: true)
                    .Build();
            }

        internal class ConfigManager : IConfigManager
        {
            private readonly IConfiguration _config;
    
            public ConfigManager()
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new Uri(codeBase);
    
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Path.GetDirectoryName(uri.LocalPath))
                    .AddJsonFile("configTestLibSettings.json");
    
                this._config = builder.Build();
            }
    
            public string Name => this._config["name"];
        }

    public class Config {
            static IConfigurationRoot config;
            static IConfigurationRoot AppConfig {
                get {
                    if (config == null) {
                        config = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json")
                                 .Build();
                    }
                    return config;
                }
            }
            public static string GetConnectionString(string name) {
                var connectionString = AppConfig.GetConnectionString(name);
                return connectionString;
            }
        }

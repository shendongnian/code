     // This class can be used for managing your AppSettings file.
    class AppSettings
    {
        private readonly IConfiguration configuration;
        public AppSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // Get the value at an specific key.
        public string GetValue(string key)
        {
            return configuration[key];
        }
    }
    class Program
    {
        // This can be used for getting an configuration builder for your config file. Pass in the config name.
        public static IConfigurationBuilder LoadConfiguration(string configFileName)
        {
            // get the file from the current directory and create an builder from it.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile(configFileName);
            return builder;
        }
        static void Main(string[] args)
        {
            // create configuration builder.
            var configuration = LoadConfiguration("appsettings.json");
            // create your AppSettings class and pass the IConfiguration object.
            AppSettings appConfig = new AppSettings(configuration.Build());
            // read the value.
            var firstItemAValue = appConfig.GetValue("Test:0:A");
            var secondItemBValue = appConfig.GetValue("Test:1:B");
            
        }
    }

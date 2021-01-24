    class TestConfig
    {
        private readonly IConfiguration configuration;
        public TestConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GetValue(string key)
        {
            return configuration[key];
        }
    }
    class Program
    {
        public static IConfigurationBuilder LoadConfiguration(string configFileName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile(configFileName);
            return builder;
        }
        static void Main(string[] args)
        {
            var a = LoadConfiguration("appsettings.json");
            TestConfig testConfig = new TestConfig(a.Build());
            var firstItemAValue = testConfig.GetValue("Test:0:A");
            var secondItemBValue = testConfig.GetValue("Test:1:B");
            
        }
    }

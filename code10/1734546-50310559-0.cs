    class Program
        {
            static void Main(string[] args)
            {
                var InMemoryValue = new Dictionary<string, string>()
                {
                    ["Configuration:Test1"] = "IndexerValue1",
                    ["Configuration:Test2"] = "IndexerValue2",
                };
    
                var configurationBuilder = new ConfigurationBuilder();
                configurationBuilder
                    .AddInMemoryCollection(InMemoryValue)
                    .AddJsonFile("Config.json")
                    ;
                var configuration = configurationBuilder.Build();
    
                Console.WriteLine("Indexer");
                Console.WriteLine($"  Test1:{configuration["Configuration:Test1"]}");
                Console.WriteLine($"  Test2:{configuration["Configuration:Test2"]}");
                Console.WriteLine($"  Test3:{configuration["Configuration:Test3"]}");
    
                var bindConfig = new Configuration();
                configuration.GetSection("Configuration").Bind(bindConfig);
                Console.WriteLine("Bind");
                Console.WriteLine($"  Test1:{bindConfig.Test1}");
                Console.WriteLine($"  Test2:{bindConfig.Test2}");
                Console.WriteLine($"  Test3:{bindConfig.Test3}");
    
                Console.Write("Press [Enter] to end.");
                Console.Read();
            }
            public class Configuration
            {
                public string Test1 { get; set; }
                public string Test2 { get; set; }
                public string Test3 { get; set; }
            }
        }

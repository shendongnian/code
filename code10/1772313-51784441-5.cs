        [FunctionName("FunctionName")]
        public static void Run(...,ExecutionContext context)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            // Get Application Settings
            var appParameter= "AzureWebJobsStorage";
            string appsetting = config[$"{appParameter}"];
            // Get Connection strings
            var connParameter= "MySqlAzureConnection";
            string connectionString = config.GetConnectionString($"{connParameter}");
        }

        [FunctionName("FunctionName")]
        public static void Run(...,ExecutionContext context)
        {
           //"Values" and "Connection" sections are injected into EnvironmentVariables automatically hence we don't need to load Json file again. 
           //Hence SetBasePath and AddJsonFile are only necessary if you have some custom settings(e.g. nested Json rather than key-value pairs) outside those two sections. It's recommended to put those setting to another file if we need to publish them.
           //Note that Function binding settings(e.g. Storage Connection String) must be EnvironmentVariables, i.e. must be stored in "Values" section.
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

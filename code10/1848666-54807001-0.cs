    public class Function {
        public static Func<IServiceProvider> ConfigureServices = () => {
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddOptions(); //OPTIONAL
            
            //...add additional services as needed
            
            //building configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            
            //Get strongly typed setting from appsettings binding to object graph
            var settings = configuration.Get<AppSettings>();
            // adding to service collection so that it can be resolved/injected as needed.
            serviceCollection.AddSingleton(settings);
            
            return serviceCollection.BuildServiceProvider();
        }
        static IServiceProvider services;
        
        static Function() { //Static ctor invokes once.
            services = ConfigureServices();
        }
        public string FunctionHandler(string input, ILambdaContext context) {
            //...
        
            var settings =  services.GetRequiredService<AppSettings>();
            var message = settings.Message;
            return message;
        }
    }
    

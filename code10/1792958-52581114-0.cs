    public class Function {
        private static IServiceProvider ConfigureServices() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient("client", client =>
            {
                client.BaseAddress = new Uri("someurl");
            });
            serviceCollection.AddTransient<ITestClass, TestClass>();
            return serviceCollection.BuildServiceProvider();
        }
        
        static IServiceProvider services;
        static Function() {
            services = ConfigureServices();
        }
        
        public async Task Handler(ILambdaContext context) {
            ITestClass test = services.GetService<ITestClass>();
            await test.RunAsync(); 
            //...
        }
    }
    

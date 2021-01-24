    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
    
            services.AddScoped<IDataProtector>();
            services.AddScoped<MyClass>();
    
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var service = serviceProvider.GetService<MyClass>();
                service.RunSample();
            }
        }
    }

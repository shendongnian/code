    using System;
    using System.Diagnostics;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace ConsoleAppDependencyInjection
    {
        class Program
        {
            static void Main(string[] args)
            {
                var serviceProvider = ConfigureContainer();
                var service1 = serviceProvider.GetService<Service1>();
                var service2 = serviceProvider.GetService<Service2>();
    
                Debug.Assert(service1 != null);
                Debug.Assert(service2 != null);
            }
    
            static IServiceProvider ConfigureContainer()
            {
                var services = new ServiceCollection();
                ConfigureServices(services);
                return services.BuildServiceProvider();
            }
    
            static void ConfigureServices(IServiceCollection services)
            {
                services.AddSingleton<Service1>();
                services.AddSingleton<Service2>();
            }
        }
    
        public class Service1
        {
            public Service1()
            {
            }
        }
    
        public class Service2
        {
            Service1 service1;
            public Service2(Service1 service1)
            {
                this.service1 = service1;
            }
        }
    }

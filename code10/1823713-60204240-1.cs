    using Microsoft.Extensions.DependencyInjection;
    
    public class Program
    {
        public static void Main(string[] args)
        {
    
            var services = new ServiceCollection();
    
            services.AddSingleton<WhateverType>(new WhateverType());
            services.AddScoped<IMyDependency, MyDependency>();
            services.AddTransient<IOperationTransient, Operation>();  
                                          
            services.AddInstance<ILoggerFactory>(new Logging.LoggerFactory());
            ILoggingFactory loggingFactor = services.GetRequiredService<ILoggerFactory>();
            ILoggingFactory loggingFactor2 = services.GetService<ILoggingFactory>();
    
            var serviceProvider = services.BuildServiceProvider();                     
            serviceProvider.GetService<WhateverType>().DoWork();
        }
    }

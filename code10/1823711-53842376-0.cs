    using Microsoft.Extensions.DependencyInjection;
    
     public class Program
        {
            public static void Main(string[] args)
            {
               
                var services = new ServiceCollection()
                    .AddSingleton<WhateverType>(new WhateverType());
    
                var serviceProvider = services.BuildServiceProvider();
                
    
                serviceProvider.GetService<WhateverType>().DoWork();
            }
        }

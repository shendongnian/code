      using Microsoft.Azure.WebJobs;
      using Microsoft.Extensions.Logging;
      using System.Configuration;
    
        namespace WebJob7
        {
            
            class Program
            {
               
                static void Main()
                {
                    var config = new JobHostConfiguration();
                    var instrumentationKey =
                       ConfigurationManager.AppSettings["APPINSIGHTS_INSTRUMENTATIONKEY"];
        
                    config.DashboardConnectionString = "";
                    
                    config.LoggerFactory = new LoggerFactory()
                        .AddApplicationInsights(instrumentationKey, null)
                        .AddConsole();
        
                    if (config.IsDevelopment)
                    {
                        config.UseDevelopmentSettings();
                    }
        
                    var host = new JobHost(config);
                   
                    host.RunAndBlock();
                }
            }
        }

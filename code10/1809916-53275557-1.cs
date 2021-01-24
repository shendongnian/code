    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using System.Configuration;
    
    namespace WebJob8
    {    
        class Program
        {       
            static void Main()
            {
                using (var loggerFactory = new LoggerFactory())
                {
                    var config = new JobHostConfiguration();
    
                    var instrumentationKey = ConfigurationManager.AppSettings["APPINSIGHTS_INSTRUMENTATIONKEY"];
                    config.DashboardConnectionString = "";
                    config.LoggerFactory = loggerFactory
                        .AddApplicationInsights(instrumentationKey, null)
                        .AddConsole();
    
                if (config.IsDevelopment)
                    {
                        config.UseDevelopmentSettings();
                    }
    
                    var host = new JobHost(config);
                    // The following code ensures that the WebJob will be running continuously
                    host.RunAndBlock();
                }
            }
        }
    }

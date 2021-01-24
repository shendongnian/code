    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    
    namespace AdvancedHost
    {
        internal class Program
        {
            private static async Task Main(string[] args)
            {
                var isService = !(Debugger.IsAttached || args.Contains("--console"));
    
                var builder = new HostBuilder()
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddHostedService<LoggingService>();
                    });
    
                if (isService)
                {
                    await builder.RunAsServiceAsync();
                }
                else
                {
                    await builder.RunConsoleAsync();
                }
            }
        }
    }

    public class Program
        {
            public static void Main(string[] args)
            {
                BuildWebHost(args).Run();
            }
    
            public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
    // Change to file post adding Application Insights Telemetry:
                    .UseApplicationInsights()
    //
                    .UseStartup<Startup>()
                    .Build();
        }

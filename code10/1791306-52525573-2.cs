    class Program
    {
        // ...
    
        // Helper method for both Main and BuildWebHost
        static IServiceProvider BuildServiceProvider(string[] args)
        {
            IServiceCollection isc = new ServiceCollection();
            ConfigureServices(isc);
            return isc.BuildServiceProvider();
        }
               
        static void Main(string[] args)
        {
             BuildServiceProvider(args).GetService<TheApp>().Run();
        }
         
        // This "WebHost" will be used by EF Core design time tools :)
        static object BuildWebHost(string[] args) =>
            new { Services = BuildServiceProvider(args) };
    }

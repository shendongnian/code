    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .YourFunction(args) //< == add an extension to IWebHostBuilder do your work
                .UseStartup<Startup>()
                .Build();
    }

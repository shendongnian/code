    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
    
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            IConfigurationRoot configurationRoot = null;
            return WebHost.CreateDefaultBuilder(args)
                     .ConfigureAppConfiguration((context, builder) =>
                      {
                          configurationRoot = builder.Build();
                      })
                      .ConfigureServices(services =>
                      {
                          services.AddSingleton<IConfigurationRoot>(configurationRoot);
                          services.AddSingleton<IConfiguration>(configurationRoot);
                      })
                     .UseStartup<Startup>();
        }
    }

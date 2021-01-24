    public class Program
    {
      public static void Main(string[] args)
      {
        CreateWebHostBuilder(args).Build().Run();
      }
      public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
          .UseShutdownTimeout(TimeSpan.FromSeconds(60)) // set timeout value here
              .UseStartup<Startup>();
      }
    }

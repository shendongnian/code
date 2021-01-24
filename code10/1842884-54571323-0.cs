    public class Program  
    {  
        public static void Main(string[] args)  
        {  
            BuildWebHost(args).Run();  
        }  
      
        public static IWebHost BuildWebHost(string[] args) =>  
            WebHost.CreateDefaultBuilder(args)  
                .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Warning))  
                .UseStartup<Startup>()  
                .Build();  
    }  

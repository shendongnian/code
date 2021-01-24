    public class Program {
        
        public static void Main(string[] args) {
            var webHost = CreateWebHostBuilder(args).Build();
            var services = webHost.Services;
            var log = services.GetService<ILogger<Program>>();
            DoStuff(log);
            webHost.Run();
        }
        static void DoStuff(ILogger<Program> log) {
            //...
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, builder) =>
                {
                    builder.AddFile(@"C:\...\log-{Date}.txt", isJson: true);
                })
                .UseStartup<Startup>();
    }

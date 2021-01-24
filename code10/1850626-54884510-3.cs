    [assembly: WebJobsStartup(typeof(StartUp))]
    public class StartUp : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddSingleton<AppSettings>();
    
            builder.Services.AddTransient<IMyService, MyService>();
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
        }
    }
    public MyFunction(IMyService service, ILogger<IMyService> logger)
    {
        this.service = service;
        this.logger = logger;
    }

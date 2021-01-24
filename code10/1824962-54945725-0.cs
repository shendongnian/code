    [assembly: WebJobsStartup(typeof(StartUp))]
    
    public class StartUp : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddTransient<IGroupService, GroupService>();
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddLogging();
        }
    }

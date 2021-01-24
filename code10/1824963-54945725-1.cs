    [assembly: WebJobsStartup(typeof(StartUp))]
    
    public class StartUp : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder webJobsBuilder)
        {
            // Enables logging and sets the minimum level of logs.
            webJobsBuilder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.SetMinimumLevel(LogLevel.Debug);
            });
            // Registers your services.
            webJobsBuilder.Services.AddTransient<IGroupService, GroupService>();
        }        
    }

    [assembly: WebJobsStartup(typeof(StartUp))]
    namespace Keystone.AzureFunctions
    {
    
        public class StartUp : IWebJobsStartup
        {
            public void Configure(IWebJobsBuilder builder)
            {           
                var connectionString = Environment.GetEnvironmentVariable("KeystoneDB");
                // Configure EF
                builder.Services.AddDbContext<KeystoneDB>(options => options.UseSqlServer(connectionString));
            }
        }
    }

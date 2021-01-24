    namespace TestAPI
    {
        public class Startup
        {
            public Startup(IHostingEnvironment env)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                    Configuration = builder.Build();
            }
    
            public IConfiguration Configuration { get; }
    
    		.
    		.
    		.
    		.
    		.
    		
        }
    }

    public class Startup
    {
        private readonly IHostingEnvironment _env;
    
        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
            // Use _env.WebRootPath here.
        }
    
        // ...
    }

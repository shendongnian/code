    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    
        private IConfiguration Configuration { get; }
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TokenProviderOptions>(Configuration);
        }
        // ...
    }

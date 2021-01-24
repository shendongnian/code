    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    
        public IConfiguration Configuration { get; }
    
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddVtaeCommonServices();
            services.AddMyServiceMX(Configuration);
            services.AddOtherService(Configuration);
    
            return VtaeConfig.ConfigVtae(services);
        }
    }

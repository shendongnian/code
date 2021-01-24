    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("dynamicRole", b => b.Requirements.Add(new DynamicRole()));
            });
            services.AddScoped<IAuthorizationHandler, DynamicRoleHandler>();
            services.Configure<AuthorizationOptions>(Configuration.GetSection("Auth"));
        }
    }

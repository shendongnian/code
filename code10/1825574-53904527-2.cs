    private IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
          Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {               
         services.Configure<Config(Configuration.GetSection("Config"));
    }

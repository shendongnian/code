    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        [...]
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(config => {
            config.Filters.Add(new EnableQueryAttribute() {
                PageSize = Configuration.GetSection("PageSize") //Get from settings
            });
        });
    }

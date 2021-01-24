    public Startup(IConfiguration configuration)
    {
    	Configuration = configuration;
    	BuildAppSettingsProvider();
    }
    
    public IConfiguration Configuration { get; }
    
    private void BuildAppSettingsProvider()
    {
    	AppSettings.ConnectionString = Configuration["ConnectionString"];
    }

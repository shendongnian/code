    IConfiguration Configuration; 
    public Startup()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        Configuration = builder.Build();
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<SupplyApiClientHttpSettings>(Configuration);
        services.AddScoped<CustomerService>();
        services.AddMvc();
    }

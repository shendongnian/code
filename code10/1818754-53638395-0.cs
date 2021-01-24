    public void ConfigureServices(IServiceCollection services)
    {
       services.AddScoped<IMyService, MyService>();
       services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

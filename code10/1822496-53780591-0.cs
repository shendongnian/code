    // MyProject project | Startup.cs
    public void ConfigureServices(IServiceCollection services)
    {
    #IF DEBUG
            services.AddScoped<IMyService, MyStubService>();
    #ELSE
            services.AddScoped<IMyService, MyService>();
    #ENDIF
    }

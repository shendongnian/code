    public void ConfigureServices(IServiceCollection services)
    {
        // Other services here.....
      
        services.AddMvc().AddJsonOptions(options => {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc()
        .AddJsonOptions(
            o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        );
    }

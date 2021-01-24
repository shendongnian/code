    public void ConfigureServices(IServiceCollection services)
    {
        ...
        var config = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfileConfiguration());
        });
        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);
        ...
    }

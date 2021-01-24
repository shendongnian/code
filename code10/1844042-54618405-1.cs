    public void ConfigureServices(IServiceCollection services)
    {
    
        // Auto Mapper Configurations
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
    
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
    
        //........
    }

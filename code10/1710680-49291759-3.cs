    public void ConfigureServices(IServiceCollection services)
    {
        var mvcBuilder = services.AddMvc();
        mvcBuilder.AddMvcOptions(o => o.Conventions.Add(new GenericControllerModelConvention()));
        mvcBuilder.ConfigureApplicationPartManager(c =>
        {
            c.FeatureProviders.Add(new GenericControllerFeatureProvider());
        });
    }

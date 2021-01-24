    public virtual void ConfigureServices(IServiceCollection services)
    {
        var mvcModule = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        foreach(var assembly in EndpointAssemblies)
        {
            mvcModule.AddApplicationPart(assembly);
        }

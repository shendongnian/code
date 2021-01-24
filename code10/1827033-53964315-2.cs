    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        var container = new WindsorContainer();
        container.Install(new WindsorConfiguration());
        return WindsorRegistrationHelper.CreateServiceProvider(container, services);
    }

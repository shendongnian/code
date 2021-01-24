    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddControllersAsServices();
        ContainerBuilder builder = new ContainerBuilder();
        builder.Populate(services);//Autofac.Extensions.DependencyInjection
        builder.RegisterType<Repository>().As<IRepository>()
            .InstancePerLifetimeScope();
        var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
            .Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
        builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();
        builder.RegisterType<Test>().As<ITest>().PropertiesAutowired();
        return new AutofacServiceProvider(builder.Build());
    }

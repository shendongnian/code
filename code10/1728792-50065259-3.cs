    private void IntegrateSimpleInjector(IServiceCollection services)
    {
        container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
    
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    
        services.AddSingleton<IControllerActivator>(
            new SimpleInjectorControllerActivator(container));
        services.AddSingleton<IViewComponentActivator>(
            new SimpleInjectorViewComponentActivator(container));
        // Enables Injection into PageModel
        services.AddSingleton<IPageModelActivatorProvider>(
                new SimpleInjectorPageModelActivatorProvider(container));
    
        services.EnableSimpleInjectorCrossWiring(container);
        services.UseSimpleInjectorAspNetRequestScoping(container);
    }
What it does, is basically call Container.GetInstance(instanceType) whenever a PageModel is being created.

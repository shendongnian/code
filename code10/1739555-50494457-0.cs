    public IContainer ApplicationContainer { get; private set; }
Change `ConfigureServices` in `Startup.cs` to return `IServiceProvider`, do all your registrations, populate the framework services in your container by using `builder.Populat(services);`. Please note that there is no need for you to do `builder.RegisterType<HomeController>().PropertiesAutowired();`
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        builder.Populate(services);
        ApplicationContainer = container;
        return new AutofacServiceProvider(ApplicationContainer);
    }
You will also need to make sure you dispose the container on application stopped by doing this in your `Configure` method.
    public void Configure(IApplicationBuilder app, IApplicationLifetime appLifetime)
    {
    	app.UseMvc();           
    	appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
    }
After you do this - your controllers should automatically get the properties autowired.

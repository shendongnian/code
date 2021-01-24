    protected void Application_Start() {
        AreaRegistration.RegisterAllAreas();
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        var services = new ServiceCollection();
        var serviceProvider = ConfigureService(services);
        var logger = serviceProvider.GetService<ILogger>();
        logger.log("About to Setup Retry Job");
        var jobScheduler = serviceProvider.GetRequiredService<IScheduler>();
         
        //...add jobs as needed
        jobScheduler.ScheduleJob(.....);
        
        //and start scheduler
        jobScheduler.Start();
    }
    private IServiceProvider ConfigureService(IServiceCollection services) {
        //Add job dependencies
        services.AddSingleton<ILogger, Logger>();
        services.AddSingleton<IPathProvider, PathProvider>();
        //add scheduler
        services.AddSingleton<IScheduler>(sp => {
            var scheduler = new StdSchedulerFactory().GetScheduler();
            scheduler.JobFactory = new MyDefaultJobFactory(sp);
            return scheduler;
        });
        
        //...add any other dependencies
        
        //build and return service provider
        return services.BuildServiceProvider();
    }
    

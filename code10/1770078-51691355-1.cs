    public void Configuration(IAppBuilder app){
        var services = new ServiceCollection();    
        ConfigureServices(services);        
        var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
        DependencyResolver.SetResolver(resolver);//Set MVC
        GlobalConfiguration.Configuration.DependencyResolver = resolver; //Set for Web API
    }

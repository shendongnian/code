    public static void Main(string[] args)
    {
    	ContainerBuilder builder = new ContainerBuilder();
    
    	builder
    		.RegisterType<Dependency>()
    		.As<IDependency>();
    
    	builder
    		.RegisterType<Final>()
    		.As<IFinal>();
    	
    	using(var container = builder.Build())
    	using (var scope = container.BeginLifetimeScope())
    	{
    
    		var finalFactory = scope.Resolve<Final.Factory>();
    		IFinal final = finalFactory(42);
    	}
    }

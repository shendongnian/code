    public static void Main(string[] args)
    {
    	ContainerBuilder builder = new ContainerBuilder();
    
    	builder
    		.RegisterType<Dependency>()
    		.As<IDependency>();
    
    	builder
    		.RegisterType<Final>()
    		.As<IFinal>();
    
    	builder
    		.RegisterType<Final>()
    		.AsSelf();
    	
    	using(var container = builder.Build())
    	using (var scope = container.BeginLifetimeScope())
    	{
    
    		var createFinal = scope.Resolve<Final.Factory>();
    		IFinal final = createFinal(42);
    	}
    }

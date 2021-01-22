    public static void Register(HttpConfiguration config)
    {
    	var container = new UnityContainer();
    	RegisterInterfaces(container);
    	config.DependencyResolver = new UnityResolver(container);
    
    	// Other Web API configuration not shown.
    }
    
    private static void RegisterInterfaces(UnityContainer container)
    {
    	var dbContext = new SchoolDbContext();
    	// Registration with constructor injection
    	container.RegisterType<IStudentRepository, StudentRepository>(new InjectionConstructor(dbContext));
    	container.RegisterType<ICourseRepository, CourseRepository>(new InjectionConstructor(dbContext));
    
    	// Set constant/default value of Pi = 3.141 
    	container.RegisterInstance<double>("PiValueExample1", 3.141);
    	container.RegisterInstance<double>("PiValueExample2", 3.14);
    	
    	// without a name
    	container.RegisterInstance<IShape>(new NoShape());
    
    	// with circle name
    	container.RegisterType<IShape, Circle>("Circle", new InjectionProperty("Name", "I am Circle"));
    	
    	// with rectangle name
    	container.RegisterType<IShape, Rectangle>("Rectangle", new InjectionConstructor("I am Rectangle"));
    
    	// Complex type like Constructor, Property and method injection
    	container.RegisterType<DIV2Controller, DIV2Controller>(
    		new InjectionConstructor("Constructor Value1", container.Resolve<IShape>("Circle"), "Constructor Value2", container.Resolve<IShape>()),
    		new InjectionMethod("Initialize"),
    		new InjectionMethod("Initialize2", "Value1", container.Resolve<IShape>("Circle"), "Value2", container.Resolve<IShape>()),
    		new InjectionProperty("MyPropertyName", "Property Value"),
    		new InjectionProperty("PiValue1", container.Resolve<double>("PiValueExample1")),
    		new InjectionProperty("Shape", container.Resolve<IShape>("Rectangle")),
    		new InjectionProperty("PiValue2", container.Resolve<double>("PiValueExample2")));
    }

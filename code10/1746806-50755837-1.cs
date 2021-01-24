	var container = new UnityContainer();
	container.RegisterType<IService, Service>(new ContainerControlledLifetimeManager());
	
	var cl1 = container.Resolve<Class1>(); // here in ctor we are setting value to 123
	var cl2 = container.Resolve<Class2>(); // here we will print it to console

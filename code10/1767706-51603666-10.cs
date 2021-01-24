	public static UnityContainer CompositionRoot()
	{
		var container = new UnityContainer();
		container.RegisterType<IDependency1, Dependency1>();
		container.RegisterType<IDependency2, Dependency2>();
		container.RegisterType<IFactory,Factory>();
		return container;
	}

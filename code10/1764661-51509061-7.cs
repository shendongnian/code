    protected override object GetInstance(Type serviceType, string key)
    {
		return _container.GetInstance(serviceType, key);
	}
	protected override IEnumerable<object> GetAllInstances(Type serviceType)
    {
		return _container.GetAllInstances(serviceType);
	}
	protected override void BuildUp(object instance)
    {
		_container.BuildUp(instance);
	}

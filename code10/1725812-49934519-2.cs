    public T GetService<T>() where T : new()
    {
    	if(!_services.ContainsKey(typeof(T)))
    	{
    		_services[typeof(T)] = new T();
    	}
    	return _services[typeof(T)] as T;
    }

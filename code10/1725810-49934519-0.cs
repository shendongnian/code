    private Dictionary<Type, Service.ServiceAbstract> _services = null;
    
    public T GetService<T>()
    {
    	return _services[typeof(T)] as T;
    }
    
    // And then use
    
    GetService<Service.ErrorService>().CreateErrorPopup(GetService<Service.LocaleService>().GetString("GENERIC_ERROR"));

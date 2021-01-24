    public sealed class AutomapServiceBehavior : Attribute, IServiceBehavior
    {
        static bool _initialised;
    
    #region IServiceBehavior Members
    	public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
    	{
            if (_initialised)  // already init'd per this AppDomain
                return;
    
    		AutomapBootstrap.InitializeMap();
            _initialised = true;
    	}
    
    	public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    	{
    	}
    
    	public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    	{
    	}
    #endregion
    }

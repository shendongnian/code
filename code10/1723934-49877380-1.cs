    public static IContainer AutofacContainer;
    private static IMyHandler _handler;
    
    private static void Main()
    {
    	try
    	{
    		if (_autofacContainer == null)
    		{
    			var builder = new ContainerBuilder();
    
    			builder.RegisterType<MyHandler>()
    				.As<IMyHandler>()
    				.SingleInstance();
    
    			_autofacContainer = builder.Build();
    
    			_handler = autofacContainer.Resolve<IMyHandler>();
    		}
    		
    		//[...] normal service registration continues here
    	}
    	catch (Exception e)
    	{
    		ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
    		throw;
    	}          
    }

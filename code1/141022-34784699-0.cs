    ServiceBase[] ServicesToRun;
    ServicesToRun = new ServiceBase[]
    {
    	new MyService()
    };
    
    if (!Environment.UserInteractive)
    {
    	// This is what normally happens when the service is run.
    	ServiceBase.Run(ServicesToRun);
    }
    else
    {
    	// Here we call the services OnStart via reflection.
    	Type type = typeof(ServiceBase);
    	BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
    	MethodInfo method = type.GetMethod("OnStart", flags);
    
    	foreach (ServiceBase service in ServicesToRun)
    	{
    		Console.WriteLine("Running " + service.ServiceName + ".OnStart()");
    		// Your Main method might not have (string[] args) but you could add that to be able to send arguments in.
    		method.Invoke(service, new object[] { args });
    	}
    
    	Console.WriteLine("Finished running all OnStart Methods.");
    
    	foreach (ServiceBase service in ServicesToRun)
    	{
    		Console.WriteLine("Running " + service.ServiceName + ".OnStop()");
    		service.Stop();
    	}
    }

    public static ILogger Create()
    {
    	var destructuringPolicies = GetAllDestructuringPolicies();
    
    	var logger = new LoggerConfiguration()
    	// snipped out all the other things that need configuring
    	// ...
    	.Destructure.With(destructuringPolicies)
    	.CreateLogger();
    
    	//Set the static instance of Serilog.Log with the same config
    	Log.Logger = logger;
    
    	logger.Debug($"Found {destructuringPolicies.Length} destructuring policies");
    	return logger;
    }
    
    /// <summary>
    /// Finds all classes that implement IDestructuringPolicy, in the assembly that is calling this 
    /// </summary>
    /// <returns></returns>
    private static IDestructuringPolicy[] GetAllDestructuringPolicies()
    {
    	var policies = Assembly.GetEntryAssembly().GetTypes().Where(x => typeof(IDestructuringPolicy).IsAssignableFrom(x));
    	var instances = policies.Select(x => (IDestructuringPolicy)Activator.CreateInstance(x));
    	return instances.ToArray();
    }

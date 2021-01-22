     public static void Configure()
            {
                ObjectFactory.Initialize(x =>
    
                x.AddRegistry(new IOCRegistry())); // in here i have registered my dependencies with for method.
                          
            }

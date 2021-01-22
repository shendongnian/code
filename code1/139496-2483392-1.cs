    ServiceHost host = new ServiceHost(typeof(MyWCFService));
    ServiceDebugBehavior debug = host.Description.Behaviors.Find<ServiceDebugBehavior>();
    
    // if not found - add behavior with setting turned on 
    if (debug == null)
    {
        host.Description.Behaviors.Add(
             new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
    }
    else
    {  
        // make sure setting is turned ON
        if (!debug.IncludeExceptionDetailInFaults)
        {
            debug.IncludeExceptionDetailInFaults = true;
        }
    }
    host.Open();

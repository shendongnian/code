    ServiceDebugBehavior behavior = 
           host.Description.Behaviors.Find<ServiceDebugBehavior>();
            
    if(behavior != null)
    {
        behavior.IncludeExceptionDetailInFaults = true;
    }
    else
    {
        host.Description.Behaviors.Add(
            new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
    }

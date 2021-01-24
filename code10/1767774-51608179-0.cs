    var originalSynchronizationContext = SynchronizationContext.Current;
    try
    {
        SynchronizationContext.SetSynchronizationContext(null);
        
        //... call your method here!
    }
    finally
    {
        SynchronizationContext.SetSynchronizationContext(originalSynchronizationContext);
    }

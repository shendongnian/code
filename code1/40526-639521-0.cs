    Monitor.Enter(sharedResource.SyncRoot);
    try
    {
    }
    finally
    {
        Monitor.Exit(sharedResource.SyncRoot);
    }

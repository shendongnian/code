    try
    {
        lock(sharedResource.SyncRoot)
        {
            int bad = 2 / 0;
        }
    }
    catch (DivideByZeroException e)
    {
       // Lock released by this point.
    }

    if (Monitor.TryEnter(someObject))
    {
        try
        {
            // use object
        }
        finally
        {
            Monitor.Exit(someObject);
        }
    }

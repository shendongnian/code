    private static object lockObject = new object();
    
    public void SingleMethod()
    {
    try
    {
    Monitor.TryEnter(lockObject,millisecondsTimeout);
    //method code
    }
    catch
    {
    }
    finally
    {
    Monitor.Exit(lockObject);
    }
    
    }

    // List for holding your disposable types
    var connectionList = new List<IDisposable>();    
    try
    { 
        // Instantiate your page states, this may be need to be done at a high level
        // These additions are over simplified, as there will be nested calls
        // building this list, in other words these will more than likely take place in methods
        connectionList.Add(x1);
        connectionList.Add(x2);
        connectionList.Add(x3);
    }
    finally
    {
        foreach(IDisposable disposable in connectionList)
        {
            try
            {
                disposable.Dispose();
            }
            catch(Exception Ex)
            {
                // Log any error? This must be caught in order to prevent
                // leaking the disposable resources in the rest of the list
            }
        }
    }

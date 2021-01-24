    object __lockObj = x;
    bool __lockWasTaken = false;
    try
    {
        System.Threading.Monitor.Enter(__lockObj, ref __lockWasTaken);
        // Your code...
    }
    finally
    {
        if (__lockWasTaken) System.Threading.Monitor.Exit(__lockObj);
    }

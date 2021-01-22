    try
    {
        if (port != null)
            port.Close(); //this will throw an exception if the port was unplugged
    }
    catch (Exception ex) //of type 'System.IO.IOException'
    {
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();
    }
    
    port = null;

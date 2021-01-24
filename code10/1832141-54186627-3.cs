    MyWcfClient proxy = new MyWcfClient
    
    try
    {
        proxy.Calculate();
        proxy.Close();
    }
    catch(Exception)
    {
        proxy.Abort();
    }

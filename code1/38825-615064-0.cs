    try
    {
        using (var svc = new ServiceReference.ServiceName())
        {
            throw new Exception("Testing");
        }
    }
    catch (Exception ex)
    {
        // What exception is caught here?
    }

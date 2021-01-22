    try
    {
        // code with Response.Redirect
    }
    catch (ThreadAbortException)
    {
        // ignore this exception, it is expected from Response.Redirect
    }
    catch (Exception ex)
    {
        // handle / log / redirect using ex
    }
    

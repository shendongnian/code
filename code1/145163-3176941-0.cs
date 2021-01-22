    if (IsRequestAvailable())
    {
        // do something with HttpContext.Current.Request...
    }
    else
    {
        // do equivalent thing without HttpContext...
    }
    
    public Boolean IsRequestAvailable()
    {
        if (HttpContext.Current == null)
            return false;
    
        try
        {
            if (HttpContext.Current.Request == null)
                return false;
        }
        catch (System.Web.HttpException ex)
        {
            if (ex.Message == "Request is not available in this context")
                return false;
    
            throw;
        }
    
        return true;
    }

    private bool IsValidHTTPURL(string url)
    {
        bool result = false;
    
        try
        {
            Uri uri = new Uri(url);
    
            result = (uri.Scheme == "http" || uri.Scheme == "https");
        }
        catch (Exception ex) 
        { 
            log.Error("Exception while validating url", ex); 
        }
    
        return result;
    }

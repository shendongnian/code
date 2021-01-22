    private static IAPISession GetTheCurrentSession()
    {
        if (SessionHasExpired)
        {
            return null;
        }
    
        // TODO: return the singleton instance here...
    
    }
    
    public IAPISession GetCurrentSession()
    {
    return GetTheCurrentSession();
    }

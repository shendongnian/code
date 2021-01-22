    public static IAPISession GetCurrentSession()
    {
        if (SessionHasExpired)
        {
            return null;
        }
    
        // TODO: return the singleton instance here...
    
    }

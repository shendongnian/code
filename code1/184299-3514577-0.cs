    // This should compile with no problems
    public IAPISession GetCurrentSession()
    {
        if (SessionHasExpired)
        {
            return null;
        }
    
        // TODO: return the singleton instance here...
    }

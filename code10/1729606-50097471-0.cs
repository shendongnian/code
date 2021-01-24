    protected virtual string ReadFromSession(string key)
    {
        return Session[key];
    }
    
    protected virtual void StoreInSession(string key, string value)
    {
        Session[key] = value;
    }

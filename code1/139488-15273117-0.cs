    public static bool IsAnonymousType(this object instance)
    {
            
        if (instance==null)
            return false;
        
        return instance.GetType().Namespace == null;
    }

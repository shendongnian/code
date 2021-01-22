    public static bool Save<T, K>(T instance)
    {
        bool idAssigned = false;
        // variable to hold object identifer
        K instanceId = default(K)
    
        PropertyInfo[] properties = typeof(T).GetProperties();
    
        foreach(PropertyInfo property in properties)
        {
            if (SomeCondition(property))
            {
                instanceId = GetId(property);
                idAssigned = true;
            }
        }
        if (!idAssigned)
        {
            return false;
        }
        Persist(whatever);
        return true;
    }

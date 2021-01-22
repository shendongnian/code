    public static bool IsEmptyEntity<T>(T obj)
    {
        foreach (var property in typeof(T).GetProperties())
            if (property.GetValue(obj, null) != null)
                return false;
        return true; 
    }

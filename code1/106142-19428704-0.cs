    public static T Parse<T>(this string target)
    {
        Type type = typeof(T);
    
        //In case of a nullable type, use the underlaying type:
        var ReturnType = Nullable.GetUnderlyingType(type) ?? type;
    
        try
        {
            //in case of a nullable type and the input text is null, return the default value (null)
            if (ReturnType != type && target == null)
                return default(T);
    
            return (T)Convert.ChangeType(target, ReturnType);
        }
        catch
        {
            return default(T);
        }
    }

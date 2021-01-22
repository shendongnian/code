    public static T To<T>(this IConvertible obj)
    {
        Type t = typeof(T);
        Type u = Nullable.GetUnderlyingType(t);
        if (u != null)
        {
            if (obj == null)
                return default(T);
            
            return (T)Convert.ChangeType(obj, u);
        }
        else
        {
            return (T)Convert.ChangeType(obj, t);
        }
    }

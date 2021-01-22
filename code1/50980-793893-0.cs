    public static T To<T>(this IConvertible obj)
    {
        Type t = typeof(T);
        if (t.IsGenericType
            && (t.GetGenericTypeDefinition() == typeof(Nullable<>)))
        {
            return (T)Convert.ChangeType(obj, Nullable.GetUnderlyingType(t));
        }
        else
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }

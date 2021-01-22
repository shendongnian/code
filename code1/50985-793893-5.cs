    public static T To<T>(this IConvertible obj)
    {
        Type t = typeof(T);
        Type u = Nullable.GetUnderlyingType(t);
        if (u != null)
        {
            return (obj == null) ? default(T) : (T)Convert.ChangeType(obj, u);
        }
        else
        {
            return (T)Convert.ChangeType(obj, t);
        }
    }

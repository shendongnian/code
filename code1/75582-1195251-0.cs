    static bool IsOneOf<T1>(object o)
    {
        return (o.GetType() == typeof (T1));
    }
    static bool IsOneOf<T1, T2>(object o)
    {
        return (o.GetType() == typeof(T1)) ||
               (o.GetType() == typeof(T2));
    }
    static bool IsOneOf<T1, T2, T3>(object o)
    {
        return (o.GetType() == typeof(T1)) ||
               (o.GetType() == typeof(T2)) ||
               (o.GetType() == typeof(T3));
    }

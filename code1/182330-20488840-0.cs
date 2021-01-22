    /// <summary>
    /// Simplifies null checking
    /// </summary>
    public static TR Get<TF, TR>(TF t, Func<TF, TR> f)
    	where TF : class
    {
    	return t != null ? f(t) : default(TR);
    }
    /// <summary>
    /// Simplifies null checking
    /// </summary>
    public static TR Get<T1, T2, TR>(T1 p1, Func<T1, T2> p2, Func<T2, TR> p3)
    	where T1 : class
    	where T2 : class
    {
    	return Get(Get(p1, p2), p3);
    }
    /// <summary>
    /// Simplifies null checking
    /// </summary>
    public static TR Get<T1, T2, T3, TR>(T1 p1, Func<T1, T2> p2, Func<T2, T3> p3, Func<T3, TR> p4)
    	where T1 : class
    	where T2 : class
    	where T3 : class
    {
    	return Get(Get(Get(p1, p2), p3), p4);
    }

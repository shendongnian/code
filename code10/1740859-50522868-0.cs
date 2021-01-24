    /// <typeparam name="T">Output type</typeparam>
    /// <typeparam name="U">Calling type</typeparam>
    /// <param name="obj">object to pipe</param>
    /// <param name="func">blackbox function</param>
    /// <returns>whatever</returns>
    public static T ForThis<T,U> (this U obj, Func<U,T> func)
    {
        return func(obj);
    }

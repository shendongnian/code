    /// <summary>
    /// Gets the result of "a == b"
    /// </summary>
    public bool GetEqualityOperatorResult<T>(T a, T b)
    {
        // declare the parameters
        var paramA = Expression.Parameter(typeof(T), nameof(a));
        var paramB = Expression.Parameter(typeof(T), nameof(b));
        // get equality expression for the parameters
        var body = Expression.Equal(paramA, paramB);
        // compile it
        var invokeEqualityOperator = Expression.Lambda<Func<T, T, bool>>(body, paramA, paramB).Compile();
        // call it
        return invokeEqualityOperator(a, b);
    }
    /// <summary>
    /// Gets the result of "a =! b"
    /// </summary>
    public bool GetInequalityOperatorResult<T>(T a, T b)
    {
        // declare the parameters
        var paramA = Expression.Parameter(typeof(T), nameof(a));
        var paramB = Expression.Parameter(typeof(T), nameof(b));
        // get equality expression for the parameters
        var body = Expression.NotEqual(paramA, paramB);
        // compile it
        var invokeInequalityOperator = Expression.Lambda<Func<T, T, bool>>(body, paramA, paramB).Compile();
        // call it
        return invokeInequalityOperator(a, b);
    }
    

    // this delegate is just, so you don't have to pass an object array. _(params)_
    public delegate T ConstructorDelegate<T>(params object[] args);
    // CreateConstructor method.
    public static ConstructorDelegate<TClass> CreateConstructor<TClass>(params Type[] parameters)
    {
        // Get the constructor info for these parameters
        var constructorInfo = typeof(TClass).GetConstructor(parameters);
        // define a object[] parameter
        var paramExpr = Expression.Parameter(typeof(Object[]));
        // To feed the constructor with the right parameters, we need to generate an array 
        // of parameters that will be read from the initialize object array argument.
        var constructorParameters = parameters.Select((paramType, index) =>
            // convert the object[index] to the right constructor parameter type.
            Expression.Convert(
                // read a value from the object[index]
                Expression.ArrayAccess(
                    paramExpr,
                    Expression.Constant(index)),
                paramType)).ToArray();
        // just call the constructor.
        var body = Expression.New(constructorInfo, constructorParameters);
        var constructor = Expression.Lambda<ConstructorDelegate<TClass>>(body, paramExpr);
        return constructor.Compile();
    }

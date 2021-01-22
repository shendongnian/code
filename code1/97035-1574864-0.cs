    ParameterExpression parameterX = Expression.Parameter(typeof(int), "x");
    ParameterExpression parameterY = Expression.Parameter(typeof(int), "y");
    ParameterExpression parameterZ = Expression.Parameter(typeof(int), "z");
    Expression multiplyYZ = Expression.Multiply(parameterY, parameterZ);
    Expression addXMultiplyYZ = Expression.Add(parameterX, multiplyYZ);
    Func<int,int,int,int> f = Expression.Lambda<Func<int, int, int, int>>
    (
        addXMultiplyYZ,
        parameterX,
        parameterY,
        parameterZ
    ).Compile();
    Console.WriteLine(f(24, 6, 3)); // prints 42 to the console

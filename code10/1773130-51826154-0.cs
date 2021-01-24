    string key = "MyProperty";
    Type keyType = typeof(T).GetProperty(key).PropertyType;
    MethodInfo methodInfo = typeof(MyClass)
        .GetMethod(
        "MyGenericStaticMethod",
        BindingFlags.NonPublic | BindingFlags.Static);
    MethodInfo genericMethodInfo = methodInfo.MakeGenericMethod(new[] { typeof(T), keyType });
    //this represents parameter of keySelector expression used in OrderBy method
    var parameterExpression = Expression.Parameter(typeof(T));
    // Expression representing call to MyGenericStaticMethod
    var expression = Expression.Call(genericMethodInfo, parameterExpression);
    // To use it as an argument of OrderBy method, we must convert expression to lambda
    var lambda = Expression.Lambda(expression, parameterExpression);

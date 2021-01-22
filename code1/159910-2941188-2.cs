    public void SetResolverMethod<T, TResult>(Expression<Func<T, Func<TResult>>> expr)
    {
        SetResolverMethod((LambdaExpression) expr);
    }
    public void SetResolverMethod<T, T1, TResult>(Expression<Func<T, Func<T1, TResult>>> expr)
    {
        SetResolverMethod((LambdaExpression) expr);
    }
    public void SetResolverMethod<T, T1, T2, TResult>(Expression<Func<T, Func<T1, T2, TResult>>> expr)
    {
        SetResolverMethod((LambdaExpression) expr);
    }
    private void SetResolverMethod(LambdaExpression expr)
    {
        var unary = (UnaryExpression) expr.Body;
        var methodCall = (MethodCallExpression) unary.Operand;
        var constant = (ConstantExpression) methodCall.Arguments[2];
        var method = (MethodInfo) constant.Value;
        Console.WriteLine(method.Name);
    }

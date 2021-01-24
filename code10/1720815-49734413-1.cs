    public Expression<Func<TSource, TDest>> Foo()
    {
        ParameterExpression parameterExpression = Expression.Parameter(typeof(TSource), "model");
        Expression arg_2E_0 = Expression.New(typeof(TDest));
        ParameterExpression[] expr_2A = new ParameterExpression[1];
        expr_2A[0] = parameterExpression;
        return Expression.Lambda<Func<TSource, TDest>>(arg_2E_0, expr_2A);
    }
    public Expression<Func<TSource, TDest>> Bar()
    {
        ParameterExpression parameterExpression = Expression.Parameter(typeof(TSource), "model");
        Expression arg_38_0 = Expression.MemberInit(Expression.New(typeof(TDest)), Array.Empty<MemberBinding>());
        ParameterExpression[] expr_34 = new ParameterExpression[1];
        expr_34[0] = parameterExpression;
        return Expression.Lambda<Func<TSource, TDest>>(arg_38_0, expr_34);
    }

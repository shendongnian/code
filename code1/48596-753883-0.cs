    public void g()
    {
        int x = 0;
        bool greaterThan = f("x > 2", x);
        bool lessThan = f("x < 2", x);
    }
    public bool f(string expression, int x)
    {
        ParameterExpression xExpr = Expression.Parameter(typeof(int), "x");
        LambdaExpression e = DynamicExpression.ParseLambda(
            new ParameterExpression[] { xExpr }, typeof(bool), expression);
        return (bool)e.Compile().DynamicInvoke(x);
    }

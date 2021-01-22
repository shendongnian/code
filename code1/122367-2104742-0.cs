    public static void Main()
    {
        String thing = "test";
        Expression<Action<String>> expression = c => c.ToUpper();
        Delegate del = expression.Compile();
        del.DynamicInvoke(thing);
        Dictionary<String, Delegate> cache = new Dictionary<String, Delegate>();
        cache.Add(GenerateKey(expression), del);
        Expression<Action<String>> expression1 = d => d.ToUpper();
        var test = cache.ContainsKey(GenerateKey(expression1));
        Console.WriteLine(test);
    }
    public static string GenerateKey(Expression<Action<String>> expr)
    {
        ParameterExpression newParam = Expression.Parameter(expr.Parameters[0].Type);
        Expression newExprBody = Expression.Call(newParam, ((MethodCallExpression)expr.Body).Method);
        Expression<Action<String>> newExpr = Expression.Lambda<Action<String>>(newExprBody, newParam);
        return newExpr.ToString();
    }

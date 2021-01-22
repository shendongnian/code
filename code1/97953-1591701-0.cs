    public static string GetMethodName(Expression<Action> exp)
    {
        var b = (MethodCallExpression)exp.Body;
        return b.Method.Name;
    }
    // ...
    var name = GetMethodName(() => myMethod(string.Empty, 0.0));
    System.Out.WriteLine(name);

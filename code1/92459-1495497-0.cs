    private T Get<T>(T task, Expression<Action<T>> method) where T : class
    {
        if (method.Body.NodeType == ExpressionType.Call)
        {
            var info = (MethodCallExpression)method.Body;
            var name = info.Method.Name; // Will return "Bark"
        }
        
        //.....
    }

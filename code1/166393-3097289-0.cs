    public static bool HasAttribute<TAttribute>(this LambdaExpression method) {
        if (method.Body.NodeType == ExpressionType.Call) {
            MethodCallExpression call = (MethodCallExpression)method.Body;
            return call.Method.GetCustomAttributes(typeof(TAttribute), true).Any();
        }
        return false;
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        var visited = base.VisitMethodCall(node);
        if (visited is MethodCallExpression mce)
        {
            if ((mce.Object == null || mce.Object is ConstantExpression)
                && mce.Arguments.All(x => x is ConstantExpression))
            {
                var obj = (mce.Object as ConstantExpression)?.Value;
                var args = mce.Arguments.Select(x => ((ConstantExpression)x).Value).ToArray();
                var result = mce.Method.Invoke(obj, args);
                return Expression.Constant(result, mce.Type);
            }
        }
        return visited;
    }

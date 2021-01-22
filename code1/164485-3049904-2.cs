    public string GetPath<T>(Expression<Func<T, object>> expr)
    {
        var stack = new Stack<string>();
        MemberExpression me;
        switch (expr.Body.NodeType)
        {
            case ExpressionType.Convert:
            case ExpressionType.ConvertChecked:
                var ue = expr.Body as UnaryExpression;
                me = ((ue != null) ? ue.Operand : null) as MemberExpression;
                break;
            default:
                me = expr.Body as MemberExpression;
                break;
        }
        while (me != null)
        {
            stack.Push(me.Member.Name);
            me = me.Expression as MemberExpression;
        }
        return string.Join(".", stack.ToArray());
    }

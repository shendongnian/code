    public string GetPath<T>(Expression<Func<T, object>> expr)
    {
        Stack<string> stack = new Stack<string>();
        MemberExpression me;
        switch (expr.Body.NodeType)
        {
            case ExpressionType.Convert:
            case ExpressionType.ConvertChecked:
                me = ((UnaryExpression)expr.Body).Operand as MemberExpression;
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

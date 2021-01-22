    public void Foo<T, P>(Expression<Func<T, P>> expr)
    {
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
            string propertyName = me.Member.Name;
            Type propertyType = me.Type;
            Console.WriteLine(propertyName + ": " + propertyType);
            me = me.Expression as MemberExpression;
        }
    }

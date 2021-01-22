    public static PropertyInfo GetProperty<T>(Expression<Func<T, object>> expression)
    {
        MemberExpression memberExpression = null;
        if (expression.Body.NodeType == ExpressionType.Convert)
        {
            memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
        }
        else if (expression.Body.NodeType == ExpressionType.MemberAccess)
        {
            memberExpression = expression.Body as MemberExpression;
        }
        return memberExpression.Member as PropertyInfo;
    }
    // usage:
    PropertyInfo p = GetProperty<MyClass>(x => x.MyCompileTimeCheckedPropertyName);

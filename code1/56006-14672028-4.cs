    public static void ThrowIfNull<T>(this Expression<Func<T>> expr)
    {
        if (expr == null)
            return;
        var param = (MemberExpression)expr.Body;
        if (((FieldInfo)param.Member).GetValue(((ConstantExpression)param.Expression).Value) == null)
            throw new ArgumentNullException(param.Member.Name);
    }

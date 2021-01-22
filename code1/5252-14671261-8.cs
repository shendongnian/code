    public static string GetParameterInfo3<T>(Expression<Func<T>> expr)
    {
        if (expr == null)
            return string.Empty;
        var param = (MemberExpression)expr.Body;
        return "Parameter: '" + param.Member.Name +
               "' = " + ((FieldInfo)param.Member).GetValue(((ConstantExpression)param.Expression).Value);
    }

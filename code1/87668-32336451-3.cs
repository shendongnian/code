    void GetString<TClass, TProperty>(string input, TClass outObj, Expression<Func<TClass, TProperty>> outExpr)
    {
        if (!string.IsNullOrEmpty(input))
        {
            var expr = (MemberExpression) outExpr.Body;
            var prop = (PropertyInfo) expr.Member;
            if (!prop.GetValue(outObj).Equals(input))
            {
                prop.SetValue(outObj, input, null);
            }
        }
    }

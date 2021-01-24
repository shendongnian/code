    static string GetJsonPropertyName<TC>(Expression<Func<TC, object>> expr)
    {
        // in case the property type is a value type, the expression contains
        // an outer Convert, so we need to remove it
        var body = (expr.Body is UnaryExpression unary) ? unary.Operand : expr.Body;
        if (body is System.Linq.Expressions.MemberExpression memberEx)
            return memberEx.Member.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;
        else
            throw new ArgumentException("expect field access lambda");
    }
    var jsonName = GetJsonPropertyName<SampleClass>(x => x.SampleClassID);

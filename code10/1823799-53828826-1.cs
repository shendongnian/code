    private static string GetPropertyPath<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
    {
        var propertyPath = new Stack<string>();
        var body = (MemberExpression)expression.Body;
        do
        {
            propertyPath.Push(body.Member.Name);
            // this will evaluate to null when we will reach ParameterExpression (x in "x => x.Foo.Bar....")
            body = body.Expression as MemberExpression;
        }
        while (body != null);
        return string.Join(".", propertyPath);
    }

    private static string GetPropertyPath<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
    {
        var propertyPath = new Stack<string>();
        var body = (MemberExpression)expression.Body;
        while (body != null)
        {
            propertyPath.Push(body.Member.Name);
            // this will evaluate to null when we will reach ParameterExpression ("x" in "x => x.Foo.Bar....")
            body = body.Expression as MemberExpression;
        }
        return string.Join(".", propertyPath);
    }

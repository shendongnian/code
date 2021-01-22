    static string GetFullPropertyName<T, TProperty>(Expression<Func<T, TProperty>> expression)
    {
        var body = expression.Body as MemberExpression;
        if (body == null)
            return string.Empty; // or throw an exception?
            
        var memberNames = new List<string>();
        while (body != null)
        {
            memberNames.Add(body.Member.Name);
            body = body.Expression as MemberExpression;
        }
        
        memberNames.Reverse();
        
        return string.Join(".", memberNames.ToArray());
    }

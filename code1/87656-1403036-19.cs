    void SetString<T>(string input, T target, Expression<Func<T, string>> outExpr)
    {
        if (!string.IsNullOrEmpty(input))
        {
            var expr = (MemberExpression) outExpr.Body;
            var prop = (PropertyInfo) expr.Member;
            prop.SetValue(target, input, null);
        }
    }
    void Main()
    {
        var person = new Person();
        SetString("test", person, x => x.Name);
        Debug.Assert(person.Name == "test");
    }

    void GetString<T>(string input, T outObj, Expression<Func<T, string>> outExpr)
    {
        if (!string.IsNullOrEmpty(input))
        {
            var expr = (MemberExpression) outExpr.Body;
            var prop = (PropertyInfo) expr.Member;
            prop.SetValue(outObj, input, null);
        }
    }
    void Main()
    {
        var person = new Person();
        GetString("test", person, x => x.Name);
        Debug.Assert(person.Name == "test");
    }

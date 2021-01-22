    void GetString<T>(string input, T obj, Expression<Func<T, string>> outputExpr)
    {
        if (!string.IsNullOrEmpty(input))
        {
            var expr = (MemberExpression) outputExpr.Body;
            var prop = (PropertyInfo) expr.Member;
            prop.SetValue(obj, input, null);
        }
    }
    void Main()
    {
        var person = new Person();
        GetString("test", person, x => x.Name);
        Debug.Assert(person.Name == "test");
    }

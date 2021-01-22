    public void AddJavaScriptToken(Expression<Func<string>> propertyExpression)
    {
        var p = GetProperty(propertyExpression);
        _javaScriptTokens.Add(p.Name, (string) p.GetValue(null, null));
    }
    public void RegisterJavaScriptTokens()
    {
        AddJavaScriptToken(() => Tokens.TOKEN_ONE);
        AddJavaScriptToken(() => Tokens.TOKEN_TWO);
    }

    void Foo()
    {
        string s = "{D}/{MM}/{YYYY}";
        s = ReplaceTokenInString(s, "{D}", "31");
        s = ReplaceTokenInString(s, "{MM}", "12");
        s = ReplaceTokenInString(s, "{YYYY}", "2009");
    }
    
    string ReplaceTokenInString(string input, string token, string replacement)
    {
        input.Replace(token, replacement);
    }

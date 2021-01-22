    public static double Evaluate(string expression)
    {
        return (double)new System.Xml.XPath.XPathDocument
        (new StringReader("<r/>")).CreateNavigator().Evaluate
        (string.Format("number({0})", new
        System.Text.RegularExpressions.Regex(@"([\+\-\*])")
        .Replace(expression, " ${1} ")
        .Replace("/", " div ")
        .Replace("%", " mod ")));
    }

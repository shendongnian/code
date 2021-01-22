    public static string LanguageLink(this HtmlHelper html, string text, string languageCode)
    {
        var routeValues = new RouteValueDictionary(html.ViewContext.RouteData.Values);
        routeValues["languageCode"] = languageCode;
    
        string action = routeValues["action"].ToString();
        return html.ActionLink(text, action, routeValues);
    }

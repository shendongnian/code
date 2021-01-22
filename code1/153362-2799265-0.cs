    public static MvcHtmlString ActionValidationSummary(this HtmlHelper html, string action)
    {
        string currentAction = html.ViewContext.RouteData.Values["action"].ToString();
 
        if (currentAction.ToLower() == action.ToLower())
            return html.ValidationSummary();
 
        return MvcHtmlString.Empty;
    }

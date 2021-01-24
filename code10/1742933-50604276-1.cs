    public static MvcHtmlString ActionLink(
        this HtmlHelper htmlHelper,
        string linkText,
        string actionName,
        object routeValues, // here you passed controllerName
        object htmlAttributes
    )

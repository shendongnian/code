    public static MvcHtmlString ActionLink(
        this HtmlHelper htmlHelper,
        string linkText,
        string actionName,
        object routeValues, // here you passed controllerName instead
        object htmlAttributes
    )
    @Html.ActionLink(linkText, actionName, routeValues, htmlAttributes)

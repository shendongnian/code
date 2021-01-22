    public static string ActionLinkNoEncode(this HtmlHelper htmlHelper, string linkText, ActionResult action )
    {
        var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);   
        var url = Uri.UnescapeDataString(urlHelper.Action(action)).ToLowerInvariant();  
        var linkTagBuilder = new TagBuilder("a");   
        linkTagBuilder.MergeAttribute("href", url);
        linkTagBuilder.InnerHtml = linkText;
        return linkTagBuilder.ToString();
    }

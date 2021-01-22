    public static class MyHtmlHelpers
    {
        public static string MySpecialActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues)
        {
            var innerTagBuilder = new TagBuilder("span") {
                InnerHtml = (!String.IsNullOrEmpty(linkText)) ? HttpUtility.HtmlEncode(linkText) : String.Empty
            };
            TagBuilder tagBuilder = new TagBuilder("a") {
                InnerHtml = innerTagBuilder.ToString(TagRenderMode.Normal);
            };
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName, routeValues);
            tagBuilder.MergeAttribute("href", url);
            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }

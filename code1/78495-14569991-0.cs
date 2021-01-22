    public static class CustomHtmlHelperExtensions
    {
        public static MvcHtmlString FormattedActionLink(this HtmlHelper html, ...)
        {
            var tagBuilder = new TagBuilder("a");
            // TODO : Implementation here
            // this syntax might not be exact but you get the jist of it!
            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }

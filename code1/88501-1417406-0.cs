    public static class MyHtmlExtensions
    {
        public static string LowerActionLink(this HtmlHelper htmlHelper,someargs)
        {
            return String.ToLowerInvariant(htmlHelper.ActionLink(someArgs));
        }
    }

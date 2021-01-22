    public static class JavaScriptExtensions
    {
        public static string JavaScript(this HtmlHelper html, string source)
        {
            TagBuilder tagBuilder = new TagBuilder("script");
            tagBuilder.Attributes.Add("type", "text/javascript");
            tagBuilder.Attributes.Add("src", VirtualPathUtility.ToAbsolute(source));
            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }

    public static class HtmlHelperExtensions
    {
        public static string Label(this HtmlHelper Html, string @for, string text)
        {
            return Html.Label(null, @for, text);
        }
        public static string Label(this HtmlHelper Html, string @for, string text, object htmlAttributes)
        {
            return Html.Label(null, @for, text, htmlAttributes);
        }
        public static string Label(this HtmlHelper Html, string @for, string text, IDictionary<string, object> htmlAttributes)
        {
            return Html.Label(null, @for, text, htmlAttributes);
        }
        public static string Label(this HtmlHelper Html, string id, string @for, string text)
        {
            return Html.Label(id, @for, text, null);
        }
        public static string Label(this HtmlHelper Html, string id, string @for, string text, object htmlAttributes)
        {
            return Html.Label(id, @for, text, new RouteValueDictionary(htmlAttributes));
        }
        public static string Label(this HtmlHelper Html, string id, string @for, string text, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            if (!string.IsNullOrEmpty(id))
                tag.MergeAttribute("id", id);
            tag.MergeAttribute("for", @for);
            tag.SetInnerText(text);
            return tag.ToString(TagRenderMode.Normal);
        }
    }

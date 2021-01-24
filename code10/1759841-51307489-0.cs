    public static IHtmlString Image(this HtmlHelper helper, string src, string alt, string height, string width)
    {
        TagBuilder tb = new TagBuilder("img");
        tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
        tb.Attributes.Add("alt", alt);
        tb.Attributes.Add("height", height);
        tb.Attributes.Add("width", width);
        return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
    }

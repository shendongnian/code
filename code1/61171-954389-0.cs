    public static IDisposable Tag(this HtmlHelper html, string tagName)
    {
        Action<string> a = tag => html.Write(String.Format(tag, tagName));
        a("<{0}>");
        return new Memento(() => a("</{0}>"));
    }

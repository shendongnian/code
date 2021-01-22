    public static IDisposable Tag(this HtmlHelper html, string tagName)
    {
        if (html == null)
            throw new ArgumentNullException("html");
        Action<string> a = tag => html.Write(String.Format(tag, tagName));
        a("<{0}>");
        return new Memento(() => a("</{0}>"));
    }

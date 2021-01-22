    public static void Write(this HtmlHelper html, string content)
    {
        if (html == null)
            throw new ArgumentNullException("html");
        html.ViewContext.HttpContext.Response.Write(content);
    }

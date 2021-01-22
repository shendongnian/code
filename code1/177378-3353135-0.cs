    public static MvcHtmlString SuperDenizControl(this HtmlHelper html)
    {
        var builder = new TagBuilder("select");
        //blah blah blah amazing control
        var control = builder.ToString();
        return MvcHtmlString.Create(control);
    }

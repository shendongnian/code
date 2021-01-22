    public static Func<HtmlHelper, PropertyViewModel, string> RenderDelegate = (a, b) =>
    {
        a.RenderPartial(b);
        return "";
    }; // Notice the semicolon here - this is really a field declaration
    public static string RenderMethod(HtmlHelper a, PropertyViewModel b)
    {
        a.RenderPartial(b);
        return "";
    }

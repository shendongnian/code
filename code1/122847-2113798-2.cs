    public static Func<HtmlHelper, PropertyViewModel, string> RenderDelegate = (a, b) =>
    {
        return a.RenderPartial(b);
    };
    
    public static string RenderMethod(HtmlHelper a, PropertyViewModel b)
    {
        return a.RenderPartial(b);
    }

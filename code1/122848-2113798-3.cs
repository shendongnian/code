    public static Func<HtmlHelper, PropertyViewModel, string> RenderDelegate = 
    delegate(HtmlHelper a, PropertyViewModel b)
    {
        return a.RenderPartial(b);
    };

    public static Func<HtmlHelper, PropertyViewModel, string> Render = 
    delegate(HtmlHelper a, PropertyViewModel b)
    {
        a.RenderPartial(b);
        return "";
    };

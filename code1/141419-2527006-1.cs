    public static string GenerateWidget<TypeOfHtmlGen, WidgetType>(this HtmlHelper htmlHelper
                                               , object modelData)
        where TypeOfHtmlGen: HtmlGenBaseClass, new()
        where WidgetType: WidgetBaseClass, new()
    {
        // Awesome stuff
    }

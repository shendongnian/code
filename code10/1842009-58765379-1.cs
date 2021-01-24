    public static class IHtmlHelperExtensions
    {
        public static string GetControllerName(this IHtmlHelper htmlHelper) =>
            htmlHelper.ViewContext.RouteData.Values["controller"].ToString();
    }

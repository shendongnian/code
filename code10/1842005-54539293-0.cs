    public static class IHtmlHelperExtensions
    {
        public static string GetControllerName<TController>(this IHtmlHelper helper)
            where TController : Controller
        {
            return typeof(TController).GetName().Replace("Controller", "");
        }
    }

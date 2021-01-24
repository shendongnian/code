    public static class HtmlExtensions
    {
        public static IHtmlContent SetDisabled(this IHtmlHelper helper, bool value)
        {
            return new HtmlString(value ? @"disabled=""disabled""" : "");
        }
    }

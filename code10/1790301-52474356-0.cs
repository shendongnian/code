    namespace System.Web.Mvc {
        public static class HtmlHelperExtensions {
            public static MvcHtmlString RenderLinkTracking(this HtmlHelper helper, string url, string linkText, string style) {
                //...
                return MvcHtmlString.Create(String.Format("<a href='{0}' style='{1}'>{2}</a>", url, style, linkText));
            }
        }
    }

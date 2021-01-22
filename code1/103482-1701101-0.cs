    using System;
    using System.Web.Mvc;
    using System.Text;
    namespace MvcApplication1.Helpers
    {
        public static class ImageHelpers
        {
            public static string ImageLink(this HtmlHelper helper, string imagepath, string url)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<a href=\"" + url + "\">");
                sb.Append("<img src=\"" + imagepath + "\" />");
                sb.Append("</a>");
                return sb.ToString();
            }
        }
    }

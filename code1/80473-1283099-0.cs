    using System.Web.Mvc.Html;
    
    public static class WindowHelper
    {
        public static void Window(this HtmlHelper helper, string name, string viewName)
        {
            var response = helper.ViewContext.HttpContext.Response;
            response.Write("<div id='" + name + "_Window' class='window'>");
    
            //Add the contents of the partial view to the string builder.
            helper.RenderPartial(viewName);
    
            response.Write("</div>");
        }
    }

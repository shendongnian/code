    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    
    namespace StackOverFlow.Extensions
    {
        public static class MyExtensions
        {
            public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null)
            {
                string cssClass = "active";
                string currentAction = (string)html.ViewContext.RouteData.Values["action"];
                string currentController = (string)html.ViewContext.RouteData.Values["controller"];
    
                if (String.IsNullOrEmpty(controller))
                    controller = currentController;
    
                if (String.IsNullOrEmpty(action))
                    action = currentAction;
    
                return controller == currentController && action == currentAction ?
                    cssClass : String.Empty;
            }
        }
    }

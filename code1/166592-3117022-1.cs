    public static class ControllerExtensions {
        public static RedirectToRouteResult CustomRedirectToRoute(this Controller controller, string controllerName, string actionName, object routevalues) {
            return CustomRedirectToRoute(controller, controllerName, actionName, new RouteValueDictionary(routevalues));
        }
        
        public static RedirectToRouteResult CustomRedirectToRoute(this Controller controller, string controllerName, string actionName, RouteValueDictionary routevalues) {
            routevalues = routevalues ?? new RouteValueDictionary();
            routevalues.Add("controller", controllerName);
            routevalues.Add("action", actionName);
            return new RedirectToRouteResult(controller.RouteData.Values["routeName"] as string, routevalues);
        }
    }

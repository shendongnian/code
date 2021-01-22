    public class LoggedUserFilterAttribute : ActionFilterAttribute
    {
        public bool Logged { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!SessionManager.IsUserLogged)
            {
                filterContext.Result = new RedirectToRouteResult(GetRedirectToNotLoggedRouteValues());
                this.Logged = false;
            }
            else
                this.Logged = true;
        }
        public RouteValueDictionary GetRedirectToNotAuthorizedRouteValues()
        {
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("action", "NotAuthorized");
            routeValues.Add("controller", "Authorization");
            return routeValues;
        }
        public RouteValueDictionary GetRedirectToNotLoggedRouteValues()
        {
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("action", "NotLogged");
            routeValues.Add("controller", "Authorization");
            return routeValues;
        }
    }

    public class SessionExpireAttribute : ActionFilterAttribute
    {
        private RouteValueDictionary LoginRougte()
        {
            return new RouteValueDictionary
            {
                {"action", "Login"},
                {"controller", "Account"},
                {"area", ""}
            };
        }
        private readonly List<string> _exceptCtrls = new List<string> { "userauth", "manager", "account" };
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var routeData = filterContext.HttpContext.Request.RequestContext.RouteData;
            var controller = routeData != null ? routeData.Values["controller"] as string : string.Empty;
            var check = !string.IsNullOrEmpty(controller) && !_exceptCtrls.Contains(controller.ToLower());
            if (check && (HttpContext.Current.Session == null || HttpContext.Current.Session.Keys.Count == 0))
            {                
                filterContext.Result = new RedirectToRouteResult(LoginRougte());
            }
            else
            {
                var timeOut = HttpContext.Current.Session.Timeout;
                HttpContext.Current.Session.Timeout = timeOut;
            }
            base.OnActionExecuting(filterContext);
        }
    }

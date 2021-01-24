    public class MyAcceptCookieCheck : ActionFilterAttribute
    {       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           var cookies = filterContext.HttpContext.Request.Cookies["OurAcceptCookie"];
            var values = filterContext.RouteData.Values.Values;
            if (cookies == null && !values.Contains("CookieConsent")) //so that it won't loop endlessly
            {                
                UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                //filterContext.Result = new RedirectResult(urlHelper.Action("CookieConsent", "Home"));
                filterContext.Result = new RedirectResult(urlHelper.Action("CookieConsent","Cookie",null,"https","www.my-domain.com/mysitename"));
            }
            else if(cookies != null)
            {
                string controllerName =  filterContext.RouteData.Values["controller"].ToString();
                string actionName = filterContext.RouteData.Values["action"].ToString();               
                UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                filterContext.Result = new RedirectResult(urlHelper.AbsolutePath(actionName, controllerName));
            }
        }
    }

    public class ViewBagValuePresentAttribute : ActionFilterAttribute
        {
    
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var s = filterContext.Controller.ViewBag.SiteID;
                if (s == null)
                {
                    UrlHelper helper = new UrlHelper(filterContext.RequestContext);
                    filterContext.Result = new RedirectResult(helper.Action("login", "Account"));
                }
                base.OnActionExecuting(filterContext);
            }

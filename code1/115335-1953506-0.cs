    public class MyBaseController : Controller
    {
      protected override void OnActionExecuting(ActionExecutingContext filterContext)
      {
         base.OnActionExecuting(filterContext);
         if (/*the user is not in the role desired*/)
         {
           RedirectToRoute(filterContext, new { controller = "MyController", action = "MyAction"});
        }
      }
      private void RedirectToRoute(ActionExecutingContext context, object routeValues)
      {
        var rc = new RequestContext(context.HttpContext, context.RouteData);
        string url = RouteTable.Routes.GetVirtualPath(rc, new RouteValueDictionary(routeValues)).VirtualPath;
        context.HttpContext.Response.Redirect(url, true);
      }
    }

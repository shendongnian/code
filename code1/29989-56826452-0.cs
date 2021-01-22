    public class IpAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
            string ips = "";
            using (var db = new DataBase())
            {
                ips = db.Configs.SingleOrDefault().IP;
            }
            if (!ips.Contains(ip))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "OutOfRange"
                }));
            }
        }
    }

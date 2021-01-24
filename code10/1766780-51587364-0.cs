    [AttributeUsage(AttributeTargets.Class |
     AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SessionTimeoutFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ISession session = filterContext.HttpContext.Session;
            
            if (session.GetString("UserID") == null)
            {
                var controller = filterContext.Controller as Controller;
    
                controller.TempData.Add("Msg", "Redirection to Login Page, Reasons : Session Timeout or Unauthorized access");
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                { "Controller", "LogIn" },
                { "Action", "Index" }
                    });
            }
            else
            {
            //redirect to dashboard or other page as per your need 
            }
            base.OnActionExecuting(filterContext);
        }
    }

        public class AdminOrBranchesAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                base.OnActionExecuting(context);
                if ((context.Controller as BaseController).Admin == null &&
                    (context.Controller as BaseController).BranchId == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Login",
                        redirectUrl = context.HttpContext.Request.Path
                    }));
                }
            }
        }

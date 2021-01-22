        public class RedirectingAction : ActionFilterAttribute
        {
          public override void OnActionExecuting(ActionExecutingContext context)
          {
            base.OnActionExecuting(context);
    
            if (CheckUrCondition)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                }));
            }
          }
       }

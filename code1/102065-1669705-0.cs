      public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var model = filterContext.Controller.ViewData.Model as YourModel;
        
            ...
        }

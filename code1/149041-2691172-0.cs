      protected override void OnActionExecuting(ActionExecutingContext filterContext)
      {
         var type1 = filterContext.Controller.GetType();
         var type2 = filterContext.ActionDescriptor
                        .ControllerDescriptor.ControllerType;
      }

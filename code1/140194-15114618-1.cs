    public class MyControllerBase
    {
       //...
       protected override void OnActionExecuted(ActionExecutedContext filterContext)
       {
           if (filterContext.Exception != null)
           {
               var targetSite = filterContext.Exception.TargetSite;
               if (targetSite.DeclaringType != null)
                   if (targetSite.DeclaringType.FullName == typeof(ActionDescriptor).FullName)
                       if (targetSite.Name == "ExtractParameterFromDictionary")  // Note: may be changed in future MVC versions
                       {
                           filterContext.ExceptionHandled = true;
                           filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
                           return;
                       }
               //...
            }
            // ...
        }
    }

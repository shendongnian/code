    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(HttpActionContext actionContext)
      {
        if(actionContext.ActionDescriptor.GetCustomAttributes<SkipMyActionFilterAttribute>().Any())
         {
           return;
         }
            
        //Do something
      }
    }

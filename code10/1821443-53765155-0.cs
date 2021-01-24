    public class DoMyPropertyAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(HttpActionContext actionContext)
      {
        if(actionContext.ActionDescriptor.GetCustomAttributes<DoMyPropertyAttribute>().Any())
        {
            //DO Something
        }
      }
    }

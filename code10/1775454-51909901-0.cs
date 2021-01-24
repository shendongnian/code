    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AllowHttpAttribute : Attribute
    {
    }
    public class RedirectToHttpsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowHttpAttribute>(false).Any())
            {
                return;
            }
            // Perform the redirect to HTTPS.
        }
    }

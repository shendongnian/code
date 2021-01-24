    public class AcceptHeaderJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));    
        }
    }
            

    using System.Web.Http.Filters;
    public class InterceptBadRequestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // whatever your condition is
            if (...)
            {
                var response = actionContext
                    .Request
                    .CreateErrorResponse(HttpStatusCode.BadRequest, "Custom error message");
                actionContext.Response = response;
            }
        }
    }

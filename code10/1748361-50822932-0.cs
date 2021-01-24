    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    public class ThrottleAttribute : ActionFilterAttribute
    {
        // Note the different signature to what you have in your question.
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //
        }
    }

    public class IgnoreNullValuesFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.ActionContext.RequestContext.Configuration.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            base.OnActionExecuted(actionExecutedContext);
        }
    }

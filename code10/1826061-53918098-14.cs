    public class SampleActionFilter : ActionFilterAttribute
    {
      private const string TimerKey = nameof(SampleActionFilter ) + "_TimerKey";
      public override void OnActionExecuting(HttpActionContext context)
      {
        context.Request.Properties[TimerKey] = DateTimeOffset.Now;
      }
      public override void OnActionExecuted(HttpActionExecutedContext context)
      {
        if (context.Result is Response response)
          && context.Request.Properties[TimerKey] is DateTimeOffset started) 
        {
          response.ServerTime = started;
          response.TimeTook = DateTimeOffset.Now - started;
        }
      }

    public class SampleActionFilter : ActionFilterAttribute
    {
      private const string TimerKey = nameof(SampleActionFilter ) + "_TimerKey";
      public override void OnActionExecuting(ActionExecutingContext context)
      {
        context.HttpContext.Items[TimerKey] = DateTimeOffset.Now;
      }
      public override void OnActionExecuted(ActionExecutedContext context)
      {
        if (context.Result is Response response)
          && context.HttpContext.Items[TimerKey] is DateTimeOffset started) 
        {
          response.ServerTime = started;
          response.TimeTook = DateTimeOffset.Now - started;
        }
      }

    public class SampleAsyncActionFilter : IAsyncActionFilter
    {
      public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
      {
        // do something before the action executes
        var started = DateTimeOffset.Now;     
        
        // Action Executes
        var resultContext = await next();
        // do something after the action executes; resultContext.Result will be set
        if  (result.Context.Result is Response response)
        {
          response.ServerTime = started;
          response.TimeTook = DateTimeOffset.Now - started;
        }
      }
    }

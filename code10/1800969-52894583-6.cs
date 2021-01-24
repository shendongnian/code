    public class CorrelationIdFilter : IActionFilter
        {
            /// <summary>
            /// Called after the action executes, before the action result.
            /// </summary>
            /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext" />.</param>
            public void OnActionExecuted(ActionExecutedContext context)
            {
            }
    
            /// <summary>
            /// Called before the action executes, after model binding is complete.
            /// </summary>
            /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
            /// <exception cref="InvalidOperationException"></exception>
            public void OnActionExecuting(ActionExecutingContext context)
            {
                context.HttpContext.Response.Headers.Add("X-Correlation-Id", Guid.NewGuid().ToString());
            }
        }

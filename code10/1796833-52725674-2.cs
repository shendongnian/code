    public class ExampleActionFilter : ActionFilterAttribute
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var memoryCache = context.HttpContext.RequestServices.GetService<IMemoryCache>();
            // …
        }
    }

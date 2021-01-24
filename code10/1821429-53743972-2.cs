    public class SmartActionFilter : IPageFilter
    {
        public void OnPageHandlerSelected(PageHandlerSelectedContext ctx) { }
        public void OnPageHandlerExecuting(PageHandlerExecutingContext ctx)
        {
            // Your logic here.
        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext ctx)
        {
            // Example requested in comments on answer.
            if (ctx.Result is PageResult pageResult)
            {
                pageResult.ViewData["Property"] = "Value";
            }
            // Another example requested in comments.
            // This can also be done in OnPageHandlerExecuting to short-circuit the response.
            ctx.Result = new RedirectResult("/url/to/redirect/to");
        }
    }

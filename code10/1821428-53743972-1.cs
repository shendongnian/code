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
        }
    }

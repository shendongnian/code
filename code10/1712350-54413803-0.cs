    // Called on incoming request
    public void OnActionExecuting(ActionExecutedContext context)
    {
        context.HttpContext.Response.OnCompleted(async () => {
            // Executed once the response is sent
            var status = context.HttpContext.Response.StatusCode;
            // Work here
            // Be careful on Transient or Scoped injections, they may already be disposed
            // If you need a DbContext, instanciate it by injecting 
            //    DbContextOptions<MyDbContext> earlier in the code
        });
    }

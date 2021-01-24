    public class CustomLayoutResultFilter : IAsyncResultFilter
    {
        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ViewResult viewResult)
            {
                if (httpContext.Request.Host == "test.example.com")
                    viewResult.ViewData["_OverwriteLayout"] = "_TestLayout";
            }
            return next();
        }
    }

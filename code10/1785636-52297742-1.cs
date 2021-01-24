    public class CustomLayoutResultFilter : IAsyncResultFilter
    {
        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ViewResult viewResult)
            {
                if (context.HttpContext.Request.Host.ToString() == "test.example.com")
                    viewResult.ViewData["_OverwriteLayout"] = "_TestLayout";
            }
            return next();
        }
    }

 cs
public class RedirectAntiforgeryValidationFailedResultFilter : IAsyncAlwaysRunResultFilter
  {
    public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
      if (context.Result is AntiforgeryValidationFailedResult result)
      {
        context.Result = new RedirectToPageResult("/AntiForgeryError");
      }
      return next();
    }
  }
I have created a razor page named `AntiForgeryError`.
At last, I have configured my app to use the `RedirectAntiforgeryValidationFailedResultFilter` in `Startup.cs`: 
 cs
services.AddMvc(options => options.Filters.Add<RedirectAntiforgeryValidationFailedResultFilter>())
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

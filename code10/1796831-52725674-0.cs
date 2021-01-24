    public class ExampleActionFilter : IAsyncActionFilter
    {
        private readonly IMemoryCache _memoryCache;
        public ExampleActionFilter(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        { … }
    }

    public class CorrelationIdFilter : IExceptionFilter, IAsyncExceptionFilter
    {
        private readonly ILogger<CorrelationIdFilter> _logger;
        /// <summary>
        /// Initialize a new instance of <see cref="CorrelationIdFilter"/>
        /// </summary>
        /// <param name="logger">A logger</param>
        public CorrelationIdFilter(ILogger<CorrelationIdFilter> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Called after an action has thrown an <see cref="T:System.Exception" />.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" /> that on completion indicates the filter has executed.
        /// </returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            Process(context);
            return Task.CompletedTask;
        }
        /// <summary>
        /// Called after an action has thrown an <see cref="T:System.Exception" />.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
        public void OnException(ExceptionContext context)
        {
            Process(context);
        }
        private void Process(ExceptionContext context)
        {
            var e = context.Exception;
            _logger.LogError(e, e.Message);
            context.HttpContext.Response.Headers.Add("X-Correlation-Id", Guid.NewGuid().ToString());
        }
    }

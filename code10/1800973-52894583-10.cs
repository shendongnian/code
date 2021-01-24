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
            if (e is InvalidOperationException)
            {
                context.Result = WriteError(HttpStatusCode.BadRequest, e);
            }
            else if (e.GetType().Namespace == "Microsoft.EntityFrameworkCore")
            {
                context.Result = WriteError(HttpStatusCode.BadRequest, e);
            }
            else
            {
                context.Result = WriteError(HttpStatusCode.InternalServerError, e);
            }                
        }
        private IActionResult WriteError(HttpStatusCode statusCode, Exception e)
        {
            var result = new ApiErrorResult(e.Message, e)
            {
                StatusCode = (int)statusCode,               
            };
            return result;
        }
    }
    /// <summary>
    /// Api error result
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ObjectResult" />
    public class ApiErrorResult : ObjectResult
    {
        private readonly string _reasonPhrase;
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorResult"/> class.
        /// </summary>
        /// <param name="reasonPhrase">The reason phrase.</param>
        /// <param name="value">The value.</param>
        public ApiErrorResult(string reasonPhrase, object value) : base(value)
        {
            _reasonPhrase = reasonPhrase;
        }
        /// <inheritdoc />
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            var reasonPhrase = _reasonPhrase;
            reasonPhrase = reasonPhrase.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)[0];
            context.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = reasonPhrase;
            await base.ExecuteResultAsync(context);
        }
    }

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHub _sentry;
        public ErrorHandlingMiddleware(RequestDelegate next, IHub sentry)
        {
            _sentry = sentry;
            _next = next;
        }
        public async Task Invoke(HttpContext context/* other dependencies */)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            if (exception is ValueNotAcceptedException) code = HttpStatusCode.NotAcceptable;
            /*if (exception is MyNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            else if (exception is MyException) code = HttpStatusCode.BadRequest;*/
            // send to Sentry.IO
            _sentry.CaptureException(exception);
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }

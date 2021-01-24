    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IHostingEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (!context.Response.HasStarted)
                    await HandleExceptionAsync(context, ex, env);
                throw;
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception, IHostingEnvironment env)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var message = exception.Message;
            switch (exception)
            {
                case NotImplementedException _:
                    code = HttpStatusCode.NotImplemented; 
                    break;
                //other custom exception types can be used here
                case CustomApplicationException cae: //example
                    code = HttpStatusCode.BadRequest;
                    break;
            }
            Log.Write(code == HttpStatusCode.InternalServerError ? LogEventLevel.Error : LogEventLevel.Warning, exception, "Exception Occured. HttpStatusCode={0}", code);
                    
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return Task.Completed;
        }
    }

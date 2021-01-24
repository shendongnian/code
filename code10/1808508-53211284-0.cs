    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate m_next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            m_next = next;
        }
        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await m_next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            string message = "Something is wrong!";
            if (exception is MyException)
            {
                httpStatusCode = HttpStatusCode.NotFound; // Or whatever status code you want to return
                message = exception.Message; // Or whatever message you want to return
            }
            string result = JsonConvert.SerializeObject(new
            {
                error = message
            });
            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }

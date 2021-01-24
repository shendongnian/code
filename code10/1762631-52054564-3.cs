    public class ApiErrorMiddleWare
    {
        private readonly RequestDelegate next;
        public ApiErrorMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is ApiAuthenticationException)
            {
                context.Response.Redirect("/account/login");
            }
            if (exception is ApiAuthorizationException)
            {
                //handle not authorized
            }
        }

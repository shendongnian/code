    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// Handles exceptions
        /// </summary>
        /// <param name="next">The next piece of middleware after this one</param>
        public ExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// The method to run in the piepline
        /// </summary>
        /// <param name="context">The current context</param>
        /// <returns>As task which is running the action</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch(Exception ex)
            {
                // Apply some logic based on the exception
                // Maybe log it as well - you can use DI in
                // the constructor to inject a logging service
                context.Response.StatusCode = //Your choice of code
                await context.Response.WriteAsync("Your message");
            }
        }
    }

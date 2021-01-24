    public sealed class HttpGlobalExceptionMiddleware
        : Microsoft.AspNetCore.Http.IMiddleware
    {
        private readonly Infrastructure.Common.ILogger logger;
        public HttpGlobalExceptionMiddleware(ILogger logger) =>
            this.logger = logger;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var error = $"An error occured: {ex.Message}";
                this.logger.LogError(error);            
                throw;
            }
        }
    }
    

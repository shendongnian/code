    public static class LogUserNameMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogUserNameMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogUserNameMiddleware>();
        }
    }

    public static class ReuqestTokenMiddlewareExctention
        {
            public static IApplicationBuilder UseTokenValidator(this IApplicationBuilder applicationBuilder)
            {
                return applicationBuilder.UseMiddleware<RequestTokenMiddleware>();
            }
        }

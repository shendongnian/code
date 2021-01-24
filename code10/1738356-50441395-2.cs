    public static class BotBuilderMiddlewareExtension {
        public static void Add<TMiddleware>(this IList<IMiddleware> middleware, IServiceCollection services) 
            where TMiddleware : IMiddleware {
            middleware.Add(new BotMiddlewareAdapter<TMiddleware>(services));
        }
    }

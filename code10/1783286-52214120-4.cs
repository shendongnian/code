    private static IApplicationBuilder UseMiddlewareInterface(IApplicationBuilder app, Type middlewareType)
    {
        return app.Use(next =>
        {
            return async context =>
            {
                var middlewareFactory = (IMiddlewareFactory)context.RequestServices.GetService(typeof(IMiddlewareFactory));
                if (middlewareFactory == null) { /* throw ... */ }
    
                var middleware = middlewareFactory.Create(middlewareType);
                if (middleware == null) { /* throw ... */ }
    
                try{
                    await middleware.InvokeAsync(context, next);
                }
                finally{
                    middlewareFactory.Release(middleware);
                }
            };
        });
    }

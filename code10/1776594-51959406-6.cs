        public IRouter BuildRouter(IApplicationBuilder applicationBuilder)
        {
            var builder = new RouteBuilder(applicationBuilder);
            // use middlewares to configure a route
            builder.MapMiddlewareGet("/api/v1/user", appBuilder => {
                appBuilder.Use(Middleware1);
                appBuilder.Use(Middleware2);
                appBuilder.Use(RequestValidationMiddleware);
                appBuilder.UseMvc();          // use a MVC here ...
            });
            builder.MapMiddlewarePost("/api/v1/user", appBuilder => {
                appBuilder.Use(Middleware1);
                appBuilder.Use(Middleware2);
                appBuilder.Use(RequestValidationMiddleware);
                appBuilder.UseMvc();
            });
            // ....
            return builder.Build();
        }

    public static void UseGlobalExceptionHandler(this IApplicationBuilder appBuilder, ILogger logger)
            {
                appBuilder.UseExceptionHandler(app =>
                {
                    app.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
    
                        var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                        //AuthException is your custom exception class
                        if (ex != null && ex.GetType() == typeof(AuthException))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync("Unautherized");
                        }
                    });
                });
            }

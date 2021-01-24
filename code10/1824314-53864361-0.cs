    app.UseExceptionHandler(builder =>
    {
        builder.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var error = context.Features.Get<IExceptionHandlerFeature>();
            var error1 = context.Features.Get<IExceptionHandlerFeature>() as ExceptionHandlerFeature;
            var error2 = context.Features.Get<IExceptionHandlerPathFeature>();
            var requestPath = error2.Path;
            if (error != null)
            {
                context.Response.ShowApplicationError(error.Error.Message, error.Error.InnerException.Message);
            }
        });
    });

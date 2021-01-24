            app.Use(async (context, next) =>
            {
                await next.Invoke();
                if (context.Response.StatusCode == StatusCodes.Status415UnsupportedMediaType)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("404 not found");
                }
            });

    app.Use(async (context, next) =>
                {
                    await next.Invoke();
    
                    if(context.Response.StatusCode == StatusCodes.Status404NotFound)
                    {
                      await context.Response.WriteAsync("You seem to have mistyped the url");
                    }               
                });

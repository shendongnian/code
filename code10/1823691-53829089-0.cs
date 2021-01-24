    app.UseStatusCodePages(ctx =>
    {
        if (ctx.HttpContext.Response.StatusCode == 405)
            ctx.HttpContext.Response.StatusCode = 404;
        
        return Task.CompletedTask;
    });

    app.UseStatusCodePages(async context =>
    {
        context.HttpContext.Response.ContentType = "text/plain";
    
        await context.HttpContext.Response.WriteAsync(
            "Status code page, status code: " + 
            context.HttpContext.Response.StatusCode);
    });

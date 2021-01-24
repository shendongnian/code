    app.Use(async (context, next) =>
    {
        if (context.Request.IsHttps || context.Request.Headers["X-Forwarded-Proto"] == Uri.UriSchemeHttps)
        {
            await next();
        }
        else
        {
            string queryString = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : string.Empty;
            var https = "https://" + context.Request.Host + context.Request.Path + queryString;
            context.Response.Redirect(https);
        }
    });

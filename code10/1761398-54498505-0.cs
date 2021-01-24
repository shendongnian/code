    using Microsoft.AspNetCore.Http;
    public Task InvokeAsync(HttpContext context)
    {
        if (found == false)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await HttpResponseWritingExtensions.WriteAsync(context.Response, "Something wrong");
        }
        return _next(context);
    }

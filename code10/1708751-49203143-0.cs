     public class AuthSchemeMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, Func<Task> next)
        {
            var scheme = context.Request.Cookies.ContainsKey("idsrv.session")
                ? "Cookies" : "Bearer";
            var result = await context.AuthenticateAsync(scheme);
            if (result.Succeeded)
            {
                context.User = result.Principal;
            }
            await next();
        }
    }

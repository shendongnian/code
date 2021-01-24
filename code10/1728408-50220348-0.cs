    private async Task _generateToken(HttpContext context)
    {
        StringValues username = context.Request.Form["username"];
        StringValues password = context.Request.Form["password"];
            
        var usermanager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
        ApplicationUser user = await usermanager.FindByNameAsync(username);
        if (user == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Invalid username or password.");
            return;
        }
        ClaimsIdentity identity = await _getIdentity(user, password);
        if (identity == null)
        {
            await usermanager.AccessFailedAsync(user);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Invalid username or password.");
            return;
        }

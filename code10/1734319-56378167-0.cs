    /// <summary>
    /// checks if current request resource can be accesses without being Windows-authenticated
    /// </summary>
    /// <param name="context">http context</param>
    /// <returns>true if non-Windows is allowed. Otherwise, false</returns>
    public static bool IsAllowedWithoutWindowsAuth(HttpContext context)
    {
        bool isAllowedWithoutWindowsAuth = context.Request.Method == "OPTIONS" ||
                                           AllowedControllers.Any(c =>
                                           {
                                               string path = context.Request.Path.ToString();
                                               return path.StartsWith(c, StringComparison.InvariantCulture);
                                           });
        return isAllowedWithoutWindowsAuth;
    }
    // custom middleware code 
    public async Task Invoke(HttpContext context)
    {
        // anonymous path, skipping
        if (IsAllowedWithoutWindowsAuth(context))
        {
            await _next(context);
            return;
        }
        if (!context.User.Identity.IsAuthenticated)
        {
            await context.ChallengeAsync("Windows");
            return;
        }
        // other code here
        await _next(context);
     }

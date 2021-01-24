    services.AddScoped<IUserInfo>(provider =>
    {
        var context = provider.GetService<IHttpContextAccessor>();
    
        return new UserInfo
        {
            UID = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
        };
    });

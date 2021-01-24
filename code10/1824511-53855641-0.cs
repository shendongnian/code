    services.AddAuthorization(options =>
    {
        options.AddPolicy("VBSession", policy =>
            policy.RequireAssertion(async ctx =>
            {
                var sessionManager = ctx.HttpContext.RequestServices.GetService<VBSessionManager>());
                var user = await sessionManager.GetCurrentSessionAsync();
                if (user == null) {
                    ctx.Fail();
                    return;
                }
            });
    });

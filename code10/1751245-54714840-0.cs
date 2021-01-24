    services.AddAuthentication().AddOAuth("LinkedIn", "LinkedIn", c =>
    {
        ...
        c.Events = new OAuthEvents()
        {
            OnRemoteFailure = (context) =>
            {
                context.Response.Redirect(context.Properties.GetString("returnUrl"));
                context.HandleResponse();
                return Task.CompletedTask;
            }
        };
    };

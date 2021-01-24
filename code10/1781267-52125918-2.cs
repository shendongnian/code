    services.AddOpenIdConnect("oidc", "Open Id connect", options =>
    {
        options.Events = new OpenIdConnectEvents()
        {
            // When a user is not active this will result in a 401
            OnAuthenticationFailed = (context) =>
            {
                // Clear the exception, otherwise it is re-thrown after this event.
                context.HandleResponse();
                // Handle the exception, e.g. redirect to an error page.
                context.Response.Redirect($"LoginError/?message={context.Exception.Message}");
                return Task.FromResult(0);
            },
        }
    }

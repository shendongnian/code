    services.AddOpenIdConnect(options =>
    {
        Configuration.Bind("<Json Config Filter>", options);
        options.Events.OnRedirectToIdentityProvider = async context =>
        {
            context.ProtocolMessage.RedirectUri = "<Return URI String>";
            await Task.FromResult(0);
        };
    });

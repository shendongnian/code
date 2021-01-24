    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        var svcProvider = services.BuildServiceProvider();
        // Add the Audit.NET custom action
        Audit.Core.Configuration.AddCustomAction(ActionType.OnScopeCreated, scope =>
        {
            // Additional information as a custom field
            var someData = svcProvider
                .GetService<IHttpContextAccessor>()
                .HttpContext.WhateverYouNeed;
            scope.Event.CustomFields["SomeData"] = someData;
        }
    }

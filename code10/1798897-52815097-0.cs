    services.AddHttpClient<IProjectManagementClient, VstsClient>("VSTS");
    services.AddHttpClient<IProjectManagementClient, JiraClient>("JIRA")
        .AddHttpMessageHandler(provider => new BasicAuthHandler(
            provider.GetService<IHttpContextAccessor>(),
            CustomClaimTypes.TrackerToken));

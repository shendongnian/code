    private static async Task EnsureConsumerGroup(string consumerGroupName)
    {
        var context = new AuthenticationContext($"https://login.windows.net/{MY_TENANT_ID}");
        
        var token = await context.AcquireTokenAsync(
            "https://management.core.windows.net/",
            new ClientCredential(MY_CLIENT_ID, MY_CLIENT_SECRET)
        );
        var serviceClientCredentials = new TokenCredentials(token.AccessToken);
        var eventHubManagementClient = new EventHubManagementClient(serviceClientCredentials)
        {
            SubscriptionId = MY_SUBSCRIPTION_ID
        };
        var consumerGroupResponse = await 
    eventHubManagementClient.ConsumerGroups.CreateOrUpdateWithHttpMessagesAsync(
            MY_RESOURCE_GROUP_NAME,
            MY_NAMESPACE_NAME,
            MY_EVENT_HUB_NAME,
            consumerGroupName,
            new ConsumerGroup() // I don't know what this parameter is supposed to do.
        );

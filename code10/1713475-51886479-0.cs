    private async Task CreateTopicSubscriptions()
    {
        var client = new ManagementClient(ServiceBusConnectionString);
        for (int i = 0; i < Subscriptions.Length; i++)
        {
            if (!await client.SubscriptionExistsAsync(TopicName, Subscriptions[i]))
            {
                await client.CreateSubscriptionAsync(new SubscriptionDescription(TopicName, Subscriptions[i]));
            }
        }
    }

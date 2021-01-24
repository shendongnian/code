    IMessageReceiver messageReceiver = new MessageReceiver(
        namespaceConnectionString,
        EntityNameHelper.FormatSubscriptionPath(topicName, subscriptionName),
        ReceiveMode.ReceiveAndDelete);
    int batchSize = 100;
    do
    {
        var messages = await messageReceiver.ReceiveAsync(batchSize);
        if (messages == null || !messages.Any()) // Returns null if no message is found
        {
           break;
        }
    }
    while (true);

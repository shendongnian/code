    IMessageReceiver messageReceiver = new MessageReceiver(
        namespaceConnectionString,
        EntityNameHelper.FormatSubscriptionPath(topicName, subscriptionName),
        ReceiveMode.ReceiveAndDelete);
    int batchSize = 100;
    var operationTimeout = TimeSpan.FromSeconds(3);
    do
    {
        var messages = await messageReceiver.ReceiveAsync(batchSize, operationTimeout);
        if (messages == null || messages.Count == 0) // Returns null if no message is found
        {
           break;
        }
    }
    while (true);

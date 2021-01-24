    IMessageReceiver messageReceiver = new MessageReceiver(
        namespaceConnectionString,
        EntityNameHelper.FormatSubscriptionPath(topicName, subscriptionName),
        ReceiveMode.ReceiveAndDelete);
    int batchSize = 100;
    do
    {
        var messages = await messageReceiver.ReceiveAsync(batchSize);
        if (messages.Count() == 0)
        {
           break;
        }
    }
    while (true);

    var messageReceiver = new MessageReceiver(connectionString, entityPath, ReceiveMode.PeekLock, prefetchCount: 1000);
    var processedLockTokens = new List<string>();
    while (true)
    {
        var messages = await messageReceiver.ReceiveAsync(maxMessageCount: 1000, operationTimeout: TimeSpan.FromSeconds(5));
        if (messages == null)
            continue;
        try
        {
            foreach (var message in messages)
            {
                // Process message.
                processedLockTokens.Add(message.SystemProperties.LockToken);
                if (isCancellationRequested)
                    return;
            }
        }
        finally
        {
            if (processedLockTokens.Any())
            {
                await messageReceiver.CompleteAsync(processedLockTokens);
                processedLockTokens.Clear();
            }
        }
    }

    private async Task StartReceiveLoop(IMessageReceiver receiver, CancellationToken cancellationToken)
    {
        int activeMessageHandlersCount = 0;
        var doneReceiving = new TaskCompletionSource<bool>();
    
        cancellationToken.Register(() =>
        {
            lock (receiver)
            {
                int attemptCount = 0;
                while (attemptCount++ < 10 && activeMessageHandlersCount > 0)
                {
                    Thread.Sleep(1000);
                }
    
                receiver.CloseAsync();
            }
    
            doneReceiving.SetResult(true);
        });
    
        receiver.RegisterMessageHandler(
            async (message, ct) =>
            {
                bool canBeProcessed;
                lock (receiver)
                {
                    canBeProcessed = !cancellationToken.IsCancellationRequested;
                    if (canBeProcessed)
                    {
                        Interlocked.Increment(ref activeMessageHandlersCount);
                    }
                }
                
                if (canBeProcessed)
                {
                    try
                    {
                        await HandleMessage(receiver, message);
                    }
                    finally
                    {
                        Interlocked.Decrement(ref activeMessageHandlersCount);
                    }
                }
                else
                {
                    await Task.Delay(60000); // Otherwise message receiver will keep pumping message during graceful shutdown
                }
            }, new MessageHandlerOptions(HandleException));
    
        await doneReceiving.Task;
    }

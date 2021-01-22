    LoopOnMessages()
    {
        lock(incomingMessages)
        {
            if (!canGrabMessage()) Monitor.Wait(incomingMessages);
        }
        if (canGrabMessage()) handleMessage();
        // loop
    }
    ReceiveMessagesAndSignalWaiters()
    {
        awaitMessagesArrive();
        lock(incomingMessages)
        {
            copyMessagesToReadyArea();
            Monitor.PulseAll(incomingMessages); //or Monitor.Pulse
        }
        awaitReadyAreaHasFreeSpace();
    }

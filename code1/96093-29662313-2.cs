    object incomingMessages = new object(); //signal object
    LoopOnMessages()
    {
        lock(incomingMessages)
        {
            Monitor.Wait(incomingMessages);
        }
        if (canGrabMessage()) handleMessage();
        // loop
    }
    ReceiveMessagesAndSignalWaiters()
    {
        awaitMessages();
        copyMessagesToReadyArea();
        lock(incomingMessages) {
            Monitor.PulseAll(incomingMessages); //or Monitor.Pulse
        }
        awaitReadyAreaHasFreeSpace();
    }

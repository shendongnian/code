    private void ProcessIncomingMessages()
    {
        while(true)
        {
            messageReset.WaitOne(100); //wait for signal
            while (messageQueue.Count > 0)
            {
                //processing messages
            }
        }
    }

    private void ProcessIncomingMessages()
    {
        while(true)
        {
            messageReset.WaitOne(); //wait for signal
            while (messageQueue.Count > 0)
            {
                //processing messages
            }
        }
    }

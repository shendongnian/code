    private BlockingCollection<byte[]> messageQueue;
    //thread 2 method
    private void ProcessIncomingMessages()
    {
        while (true)
        {
            //will block until thread1 Adds a message
            byte[] message = messageQueue.Take();
            //processing messages
        }
    }
    public void SubmitMessageForProcessing(byte[] message)
    {
        messageQueue.Add(message); //enqueue message
    }

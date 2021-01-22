    class MSMQListener
    {
        public void StartListening(string queuePath)
        {
            MessageQueue msQueue = new MessageQueue(queuePath);
            msQueue.ReceiveCompleted += QueueMessageReceived;
            msQueue.BeginReceive();
        }
        private void QueueMessageReceived(object source, ReceiveCompletedEventArgs args)
        {
            MessageQueue msQueue = (MessageQueue)source;
            //once a message is received, stop receiving
            Message msMessage = null;
            msMessage = msQueue.EndReceive(args.AsyncResult);
            //do something with the message
            //begin receiving again
            msQueue.BeginReceive();
        }
    }

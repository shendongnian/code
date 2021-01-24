    private BlockingCollection<Message> _outboundMessages;
    private void ConsumerThread()
    {
        // This will block until new messages are queued
        foreach (var item in _outboundMessages.GetConsumingEnumerable())
        {
            SendMessage(message, _tradeStreamSSL);
        }
    }

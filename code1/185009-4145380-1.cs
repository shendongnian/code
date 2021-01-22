    public SimpleQueueListener CreateSimpleQueueListener(IMessageProcessor processor)
    {
        var listenerSession = this.connection.CreateSession();
        IMessageConsumer consumer = listenerSession.CreateConsumer(this.queue, "2 > 1");
        return new SimpleQueueListener(consumer, processor, listenerSession);
    }

    public ConcurrentDictionary<TMessage, string> MessageList { get; set; }
    public Handler(ConcurrentDictionary<TMessage, string> messageList)
    {
        MessageList = messageList;
    }
    ...
    private void ReceivedMessages(TMessage Message)
    {
        MessageList.TryAdd(message, "");
    }

    IMessage message = .. // Assume the message has been deserialised from some data stream.
    var messageType message.GetType();
    if (messageHandlers.ContainsKey(messageType))
    {
        var component = messageHandlers[messageType];
        Debug.Assert(messageType == component.MessageType);
        component.HandleMessage(message);
    }
    else
    {
        Console.WriteLine(string.Format("Message handler not found for type {0}", messageType.FullName));
    }

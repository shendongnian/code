    public async Task<WxMessage> HandleMessage(IWxMessage message) 
    {
        var messageType = message.GetType();
        var messageHandlerType = typeof(IWxMessageHandler<>).MakeGenericType(messageType);
        var handler = _serviceProvider.GetService(messageHandlerType);
        // …
    }

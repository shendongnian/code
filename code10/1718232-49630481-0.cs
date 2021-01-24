    foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
    {
        ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
        channelDispatcher.ErrorHandlers.Add(errorHandler);
    }

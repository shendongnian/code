    public void Ping()
    {
        var messageEncoderSettings = GetMessageEncoderSettings();
        var operation = new PingOperation(messageEncoderSettings);
        var server = GetServer();
        using (var channelSource = new ChannelSourceHandle(new ServerChannelSource(server)))
        using (var channelSourceBinding = new ChannelSourceReadWriteBinding(channelSource, ReadPreference.PrimaryPreferred))
        {
            operation.Execute(channelSourceBinding, CancellationToken.None);
        }
    }

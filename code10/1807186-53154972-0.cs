    public async Task<double> RemoteTimeConsumingRemoteCall()
    {
        var timeConsumingCallDelegate = new TimeConsumingCallDelegate(service.TimeConsumingRemoteCall);
        return await Task.Factory.FromAsync
            (
                timeConsumingCallDelegate.BeginInvoke(null, null),
                timeConsumingCallDelegate.EndInvoke
           );
    }

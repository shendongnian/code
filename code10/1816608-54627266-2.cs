    public async Task StartAsync()        {
        await Task.Run(() => ThreadBody())
    }
    public void Stop()
    {
        _poller.Stop();
    }
        private void ThreadBody()
    {
        using (PullSocket receiverSocket = new PullSocket())
        using (_poller = new NetMQPoller())
        {
            receiverSocket.Connect($"tcp://{_address}:{_port}");
            receiverSocket.ReceiveReady += receiver_ReceiveReady;
            _poller.Add(receiverSocket);
            _poller.Run();
        }
    }

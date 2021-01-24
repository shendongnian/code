    private void ReceiveData(CancellationToken cancellationToken)
    {
        while (true)
        {
            bool receivedTopicMessage = SubSocket.TryReceiveFrameBytes(TimeSpan.Zero, out byte[] messageTopicReceived);
            bool receivedMessage = SubSocket.TryReceiveFrameBytes(TimeSpan.Zero, out byte[] messageReceived);
    
            Task.Delay(1000, cancellationToken);
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
        }
        //Code that uses byte array and do stuff
    }

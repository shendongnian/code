    using (var client = _listener.EndAcceptTcpClient(ar))
    {
        var clientStream = client.GetStream();
        using (var eh = new ManualResetEvent(false))
        {
            // Get the request message 
            Messages.ReceiveMessage(clientStream, msg =>
                {
                    ProcessRequest(msg, clientStream);
                    eh.Set();
                });
    
            eh.WaitOne();
        }
    }

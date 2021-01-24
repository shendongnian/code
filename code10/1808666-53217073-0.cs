    #Client.cs
    
    private AutoResetEvent[] _autoSendReceiveEvents;
    
    ##Connection method
        using (var connectArgs = new SocketAsyncEventArgs())
        {
            connectArgs.AcceptSocket = _socket;
            connectArgs.RemoteEndPoint = _ipEndPoint;
            connectArgs.Completed += OnCompleted;
    
            var result = _socket.ConnectAsync(connectArgs);
            if (result)
            {
               _autoConnectEvent.WaitOne();
            }
    
            var errorCode = connectArgs.SocketError;
            if (errorCode != SocketError.Success)
            {
                    CloseSocket();
                    throw new SocketException((int) errorCode);
            }
        }
    ##Sending Data
        public void Send(string message)
            {
                if (!IsConnected)
                {
                    throw new SocketException((int) SocketError.NotConnected);
                }
    
                var sendBuffer = GetBytes(message);
                using (var sendReceiveArgs = new SocketAsyncEventArgs())
                {
                    sendReceiveArgs.SetBuffer(sendBuffer, 0, sendBuffer.Length);
                    sendReceiveArgs.AcceptSocket = _socket;
                    sendReceiveArgs.RemoteEndPoint = _ipEndPoint;
                    sendReceiveArgs.Completed += OnSend;
                    var result = _socket.SendAsync(sendReceiveArgs);
                    if (result)
                    {
                        _autoSendReceiveEvents[SendOperation].WaitOne();
                    }
                }
            }
    
    ##OnSend
     
        private void OnSend(object sender, SocketAsyncEventArgs eventArgs)
        {
                try
                {
                    if (eventArgs.SocketError != SocketError.Success)
                    {
                        CloseSocket();
                        _autoSendReceiveEvents[SendOperation].Set();
                    }
    
                    switch (eventArgs.LastOperation)
                    {
                        case SocketAsyncOperation.Send:
                            _autoSendReceiveEvents[SendOperation].Set();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    CloseSocket();
                    _autoSendReceiveEvents[SendOperation].Set();
                }
        }

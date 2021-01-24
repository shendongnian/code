    if (_socket == null)
    {
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }
    if (_socket.IsConnected() || _isConnecting)
    {
        return;
    }
    _isConnecting = true;
    _socket.Connect(new IPEndPoint(_ipAddress, _port));
    _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnIncomingData, _socket);

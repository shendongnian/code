     try
     {
        _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnIncomingData, _socket);
     }
     catch (SocketException ex)
     {
        if (ex.SocketErrorCode == SocketError.ConnectionReset)
        {
           //Do Something
        }
     }

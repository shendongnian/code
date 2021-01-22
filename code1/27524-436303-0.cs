protected override bool NetworkHasData() 
{
    if (_socket == null)
        return false;
    // Tells the state of the connection as of the last activity on the socket
    if (!_socket.Connected)
    {
        OnNetworkError(null, true);
        return false;
    }
    // This is the recommended way to determine if a socket is still active, make a
    // zero byte send call, and see if an exception is thrown.  See the Socket.Connected
    // MSDN documentation.  Only do the check when we know there's no data available
    try
    {
        List<Socket> readSockets = new List<Socket>();
        readSockets.Add(_socket);
        Socket.Select(readSockets, null, null, 100000);
        if (readSockets.Count == 1)
        {
            if (_socket.Available > 0)
                return true;
            OnNetworkError(null, true);
            return false;
        }
        _socket.Send(new byte[1], 0, 0);
    }
    catch (SocketException e)
    {
        // 10035 == WSAEWOULDBLOCK
        if (!e.NativeErrorCode.Equals(10035))
            OnNetworkError(e, true);
    }
    return false;
}

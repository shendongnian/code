    public bool IsConnected()
    {
        return !(!_socket.Poll(1, SelectMode.SelectRead)
                                    && _socket.Available == 0);
    }

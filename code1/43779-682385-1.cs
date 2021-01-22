    public bool IsConnected
    {
             get {return !(Socket.Poll(1, SelectMode.SelectRead) 
                                      && m_socket.Available ==0)}
    }

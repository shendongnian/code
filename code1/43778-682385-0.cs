    public bool IsConnected()
        {
            if(socket.Poll(1, SelectMode.SelectRead) && m_socket.Available ==0)
                    return false;
            return true;
        }

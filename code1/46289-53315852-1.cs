    // Determines whether the remote end has called Shutdown
    public bool HasRemoteEndShutDown
    {
        get
        {
            try
            {
                int bytesRead = socket.Receive(new byte[1], SocketFlags.Peek);
                if (bytesRead == 0)
                    return true;
            }
            catch
            {
                // For a non-blocking socket, a SocketException with 
                // code 10035 (WSAEWOULDBLOCK) indicates no data available.
            }
            return false;
        }
    }

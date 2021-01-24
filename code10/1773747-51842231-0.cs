    public bool Connect() {
        if(_socket == null) // Initialize the _socket object
        if(_socket.IsConnected()) return true;
        
        try {
            _socket.Connect(new IPEndPoint(_ipAddress, _port));
            return true;
        }
        catch(SocketException e) {
            // Error handling such as logging, error prompt, or reconfigure & retry
            return false;
        }
    }
    public bool Send(string msg) {
        try {
            if(!Connect()) // Throw Exception
            // Insert sending logic
            return true;
        } 
        catch (Exception e) {
            // Error Handling
            return false;
        }
        finally {
            // Maybe insert close socket logic
        }
    }

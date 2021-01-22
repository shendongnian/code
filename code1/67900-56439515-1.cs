     public static bool ConnectWithTimeout(this Socket socket, string host, int port, int timeout)
            {
                bool connected = false;
                Task result = socket.ConnectAsync(host, port);               
                int index = Task.WaitAny(new[] { result }, timeout);
                connected = socket.Connected;
                if (!connected) {
                  socket.Close();
                }
    
                return connected;
            }

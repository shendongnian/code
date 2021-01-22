    private void acceptCallback(IAsyncResult result)
        {
           xConnection conn = new xConnection();
           try
           {
             //Finish accepting the connection
             System.Net.Sockets.Socket s = (System.Net.Sockets.Socket)result.AsyncState;
             conn = new xConnection();
             conn.socket = s.EndAccept(result);
             conn.buffer = new byte[_bufferSize];
             lock (_sockets)
             {
               _sockets.Add(conn);
             }
             //Queue recieving of data from the connection
             conn.socket.BeginReceive(conn.buffer, 0, conn.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), conn);
           }
           catch (SocketException e)
           {
             if (conn.socket != null)
             {
               conn.socket.Close();
               lock (_sockets)
               {
                 _sockets.Remove(conn);
               }
             }
           }
           catch (Exception e)
           {
             if (conn.socket != null)
             {
               conn.socket.Close();
               lock (_sockets)
               {
                 _sockets.Remove(conn);
               }
             }
           }
           finally
           {
             //Queue the next accept, think this should be here, stop attacks based on killing the waiting listeners
             _serverSocket.BeginAccept(new AsyncCallback(acceptCallback), _serverSocket);       
           }
         }

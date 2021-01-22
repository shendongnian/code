    protected void ReceiveCallback(IAsyncResult ar)
    {
         var so = (StateObject)ar.AsyncState;
         if (!so.Socket.Connected) return;
     
         try
         {
             int read = so.Socket.EndReceive(ar);
             if (read > 0)
             ProcessBuffer(so, so.Buffer, read);
        
             so.Socket.BeginReceive(so.Buffer, 0, so.Buffer.Length, SocketFlags.None, ReceiveCallback, so);
          }
          catch (SocketException e)
          {
              Trace.WriteLine("[Networking]::NetBase.ReceiveCallback: SocketException");
              Output.WriteLine(e.Message);
              RaiseDisconnected();
          }
          catch (ObjectDisposedException e)
          {
              Trace.WriteLine("[Networking]::NetBase.ReceiveCallback: ObjectDisposedException");
              Output.WriteLine(e.Message);
              RaiseDisconnected();
           }
    }

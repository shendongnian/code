    private void AcceptCon(IAsyncResult iar)
    {
            
        Socket s = (Socket)iar.AsyncState;
        Socket s2 = s.EndAccept(iar);
        SocketStateObject state = new SocketStateObject();
        state.workSocket = s2;
        
        allDone.Set(); // <------
        
        s2.BeginReceive(state.buffer, 0, SocketStateObject.BUFFER_SIZE, 0,
            new AsyncCallback(Read), state);
        
    }
              

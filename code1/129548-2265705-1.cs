    void AcceptConnection(IAsyncResult asyncRes)
    {
    	connectDone.Set();
    	System.Net.Sockets.Socket s = channelworker.EndAccept(asyncRes);
    	byte[] messagebuffer = new byte[bufferSize];
    
    	/*
    	 * Tell socket to begin Receiving from caller.
    	 */
    	s.BeginReceive(messageBuffer, 0, messageBuffer.Length,
    		System.Net.Sockets.SocketFlags.None, new AsyncCallback(Receive), s);
                                    
    	/* 
    	 * Tell Channel to go back to Accepting callers.
    	 */
    	connectDone.Reset();
    	sock.BeginAccept(new AsyncCallback(AcceptConnection), sock);
    	connectDone.WaitOne();
    }

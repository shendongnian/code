    // You'll need some state object, if you don't already have one
    class AsyncServerState
    {
       public byte[] Buffer = new byte[8192]; // 8K buffer
       public StringBuilder Content = new StringBuilder0; // Place to store the content as it's received
       public SocketAsyncEventArgs ReadEventArgs = new SocketAsyncEventArgs();
       public Socket Client;
    }
    
    // You'll need to setup the state where ever you process your connect
    // something similar to this.
    void Accept_Completed(object sender, SocketAsyncEventArgs e)
    {
        if (e.SocketError == SocketError.Success)
        {
            Socket client = e.AcceptSocket;
            AsyncServerState state = new AsyncServerState();
            state.ReadEventArgs.AcceptSocket = client;
            state.ReadEventArgs.Completed += new EventHandler(                                              IO_Completed);
            state.ReadEventArgs.UserToken = state;
            state.Client = client;
            state.ReadEventArgs.SetBuffer(state.Buffer, 0, state.Buffer.Length);
    
            if (!client.ReceiveAsync(state.ReadEventArgs))
            {   
                // Call completed synchonously
                ProcessReceive(state.ReadEventArgs);
            }
        }
        ProcessAccept(e);
    }
    
    private void ProcessReceive(SocketAsyncEventArgs e)
    {        
        var state = e.UserToken as AsyncServerState;
    
        // Check if the remote host closed the connection.
        if (e.BytesTransferred > 0)
        {
            if (e.SocketError == SocketError.Success)
            {
                // Get the message received from the listener.
                sting content = Encoding.ASCII.GetString(state.Buffer, 0, e.BytesTransferred);
                 
                // Append the received data to our state
                state.Content.Append(content);                          
    
                // Increment the count of the total bytes receive by the server
                Interlocked.Add(ref this.totalBytesRead, bytesTransferred);
    
                if (content.IndexOf(Convert.ToString((char)3)) > -1)
                {
                    // Final Message stored in our state
                    string finalContent = state.Content.ToString();
                    return;                
                }
                else
                {
                    // You need to issue another ReceiveAsync, you can't just call ProcessReceive again
                    if (!state.Client.ReceiveAsync(state.ReadEventArgs))
                    {
                        // Call completed synchonously
                        ProcessReceive(state.ReadEventArgs);
                    }                
                }
            }
            else
            {
                this.CloseClientSocket(e);
            }
        }
    }

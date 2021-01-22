    /// 
    /// Server state holds current state of the client socket
    ///
    class AsyncServerState
    {
       public byte[] Buffer = new byte[512]; //buffer for network i/o
       public int DataSize = 0; //data size to be received by the server
      
       //flag that indicates whether prefix was received
       public bool DataSizeReceived = false;
       public MemoryStream Data = new MemoryStream(); //place where data is stored
       public SocketAsyncEventArgs ReadEventArgs = new SocketAsyncEventArgs();
       public Socket Client;
    }
    /// 
    /// Implements server receive logic
    /// 
    private void ProcessReceive(SocketAsyncEventArgs e)
    {
        //single message can be received using several receive operation
        AsyncServerState state = e.UserToken as AsyncServerState;
        if (e.BytesTransferred <= 0 || e.SocketError != SocketError.Success)
        {
            CloseConnection(e);
        }
        int dataRead = e.BytesTransferred;
        int dataOffset = 0;
        int restOfData = 0;
        while (dataRead > 0)
        {
            if (!state.DataSizeReceived)
            {
                //there is already some data in the buffer
                if (state.Data.Length > 0)
                {
                    restOfData = PrefixSize - (int)state.Data.Length;
                    state.Data.Write(state.Buffer, dataOffset, restOfData);
                    dataRead -= restOfData;
                    dataOffset += restOfData;
                }
                else if (dataRead >= PrefixSize)
                {   //store whole data size prefix
                    state.Data.Write(state.Buffer, dataOffset, PrefixSize);
                    dataRead -= PrefixSize;
                    dataOffset += PrefixSize;
                }
                else
                {   // store only part of the size prefix
                    state.Data.Write(state.Buffer, dataOffset, dataRead);
                    dataOffset += dataRead;
                    dataRead = 0;
                }
                if (state.Data.Length == PrefixSize)
                {   //we received data size prefix
                    state.DataSize = BitConverter.ToInt32(state.Data.GetBuffer(), 0);
                    state.DataSizeReceived = true;
                    state.Data.Position = 0;
                    state.Data.SetLength(0);
                }
                else
                {   //we received just part of the headers information
                    //issue another read
                    if (!state.Client.ReceiveAsync(state.ReadEventArgs))
                        ProcessReceive(state.ReadEventArgs);
                        return;
                }
            }
            //at this point we know the size of the pending data
            if ((state.Data.Length + dataRead) >= state.DataSize)
            {   //we have all the data for this message
                restOfData = state.DataSize - (int)state.Data.Length;
                state.Data.Write(state.Buffer, dataOffset, restOfData);
                Console.WriteLine("Data message received. Size: {0}",
                                      state.DataSize);
                dataOffset += restOfData;
                dataRead -= restOfData;
                state.Data.SetLength(0);
                state.Data.Position = 0;
                state.DataSizeReceived = false;
                state.DataSize = 0;
                if (dataRead == 0)
                {
                    if (!state.Client.ReceiveAsync(state.ReadEventArgs))
                        ProcessReceive(state.ReadEventArgs);
                        return;
                }
                else
                    continue;
            }
            else
            {   //there is still data pending, store what we've
                //received and issue another BeginReceive
                state.Data.Write(state.Buffer, dataOffset, dataRead);
                if (!state.Client.ReceiveAsync(state.ReadEventArgs))
                    ProcessReceive(state.ReadEventArgs);
                dataRead = 0;
            }
        }
    }

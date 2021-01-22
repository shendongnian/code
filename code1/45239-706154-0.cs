        private void ReceiveCallback(IAsyncResult ar)
        {
            int bytesRead = 0;
            try
            {
                // receive finished
                if (ar.IsCompleted)
                {
                    TcpIpState stateObject = (TcpIpState)ar.AsyncState;
                    bytesRead = stateObject.TcpIpSocket.EndReceive(ar, out seSocketError);
                    if (bytesRead > 0)
                    {
                        foreach (ArraySegment<byte> asBuffer in stateObject.Buffer)
                        {
                                stateObject.SBuilder.Append(
                                    Encoding.ASCII.GetChars(
                                    asBuffer.Array,
                                    0,
                                    asBuffer.Count));
                        }
                        // Let the owner object know of the received message
                        base.EnqueueMessage(new TcpIpMessage(stateObject.SBuilder.ToString()));
                        // Start a new receive operation
                        stateObject.SBuilder = new StringBuilder();
                        stateObject.Buffer.Clear();
                        stateObject.Buffer.Add(new ArraySegment<byte>(new byte[_bufferSize]));
                        stateObject.TcpIpSocket.BeginReceive(
                            stateObject.Buffer,
                            SocketFlags.None,
                            new AsyncCallback(ReceiveCallback),
                            stateObject);
                    }
                    else
                    {
                        OnDisconnected(this, new Exception("Bytes returned are 0"));
                        Disconnect();
                    }
                }
            }
            catch (Exception e)
            {
                // Something has gone wrong on a low level portion
                OnDisconnected(this, e);
                Disconnect();
            }
        }

    //added event, SomeDataObject is for you to create.
    public event EventHandler<SomeDataObject> MessageProcessed;
    public void ReceiveBytes()
    {
        byte[] receivedPacket;
        while (IsListeningForBytes)
        {
            receivedPacket = new byte[Packet.BUFFERSIZE];
            try
            {
                int bytesRead = ClientSocket.Receive(receivedPacket, SocketFlags.None);
                if (bytesRead > 0)
                {
                    SocketObject.ProcessMessage(receivedPacket);
                    // no UI update but fire an event
                    MessageProcessed?.Invoke(this, new SomeDataObject());
                }
                else
                {
                    throw new Exception("No bytes read");
                }
            }
            catch (Exception ex)
            {
                IsListeningForBytes = false;
                Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }

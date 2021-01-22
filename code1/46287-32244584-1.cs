    public void OnDataReceived(IAsyncResult asyn)
    {
        try
        {
            SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
            int iRx = socket.EndReceive(asyn);
        catch (SocketException ex)
        {
            SocketExceptionCaught(ex);
        }
    }

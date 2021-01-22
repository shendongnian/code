    public void ByteReceived(IAsyncResult ar)
    {
        string res = Encoding.ASCII.GetString(oneChar);
        if (res[0] == 0x4)
        {
           //fire some event 
        }
        else
        {
           AsyncCallback onreceive = ByteReceived;
           socket.BeginReceive(oneChar, 0, 1, SocketFlags.None, onreceive, null);
        }
    }

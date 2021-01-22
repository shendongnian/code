    public void Send(string xmlString)
    {
        byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlString);
        byte[] sizeBytes = BitConverter.GetBytes(xmlBytes.Length);
    
        SendInternal(sizeBytes);
        SendInternal(xmlBytes);
    }
    
    const int ChunkSize = 1492;
    
    void SendInternal(byte[] data)
    {
        int size = data.Length;
        int sent = 0;
        int count = 0;
        while (sent < size)
        {
            count = Math.Min(ChunkSize, size - sent);
            count = socket.Send(data, sent, count, SocketFlags.None);
            sent += count;
        }
    }

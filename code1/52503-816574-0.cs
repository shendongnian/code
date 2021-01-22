    using (var resultStream = new MemoryStream())
    {
        const int CHUNK_SIZE = 2 * 1024; // 2KB, could be anything that fits your needs
        byte[] buffer = new byte[CHUNK_SIZE];
        int bytesReceived;
        while ((bytesReceived = socket.Receive(buffer, buffer.Length, SocketFlags.None)) > 0)
        {
            byte[] actual = new byte[bytesReceived];
            Buffer.BlockCopy(buffer, 0, actual, 0, bytesReceived);
            resultStream.Write(actual, 0, actual.Length);
        }
    
        // Do something with the resultStream, like resultStream.ToArray() ...
    }

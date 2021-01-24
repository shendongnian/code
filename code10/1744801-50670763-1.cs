    private static byte[] GetTcpResponse()
    {
        var data = new List<byte>();
        var buffer = new byte[512]; //size can be different, just an example
        var terminatorReceived = false;
        while(!terminatorReceived)
        {
            var bytesReceived = tcpClient.Client.Receive(buffer);
            if(bytesReceived > 0)
            {
                data.AddRange(buffer.Take(bytesReceived));
                terminatorReceived = data.Contains(0xFD);
            }
        }
        return data.ToArray();
    }

    public static async Task<string> SendRecOne(string dataToSvr)
    {
        progressBar.Visibility = Visibility.Visible;
        string ToReturn = null;
        using (TcpClient client = new TcpClient(SERVER_NAME, PORT))
        {
            int ByteCount = Encoding.ASCII.GetByteCount(dataToSvr); //How much bytes?
            byte[] ByteBuffer = new byte[1024]; //initialize byte array
            ByteBuffer = Encoding.ASCII.GetBytes(dataToSvr);
            NetworkStream stream = client.GetStream();
            await stream.WriteAsync(ByteBuffer, 0, ByteBuffer.Length);
            //byte[] responseData = new byte[client.ReceiveBufferSize];
            //int bytesRead = await stream.ReadAsync(responseData, 0, client.ReceiveBufferSize);
            int i;
            ByteBuffer = new byte[ByteBuffer.Length];
            MemoryStream ms = new MemoryStream();
            if (stream.DataAvailable)
            {
                while ((i = await stream.ReadAsync(ByteBuffer, 0, ByteBuffer.Length)) != 0)
                {
                    await ms.WriteAsync(ByteBuffer, 0, ByteBuffer.Length);
                    if (!stream.DataAvailable)
                        break;
                }
                ToReturn = Encoding.ASCII.GetString(ms.ToArray());
            }
            progressBar.Visibility = Visibility.Collapsed;
        }
        return ToReturn;
    }

    TcpClient client = new TcpClient("169.254.74.65", 7998);
    NetworkStream stream = client.GetStream();
    Byte[] data = new Byte[1024];
    String responseData = String.Empty;
    Int32 bytes;
    while(true) {
        bytes = stream.Read(data, 0, data.Length);
        if (bytes > 0) {
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
        }
    }
    stream.Close();
    client.Close();

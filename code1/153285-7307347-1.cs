    Bitmap tImage = new Bitmap(Image URL goes here);
    byte[] bStream = ImageToByte(tImage);
    
    while (true)
    {
        // The 'using' here will call Dispose on the client after data is sent.
        // This will disconnect the client
        using (TcpClient client = server.AcceptTcpClient())
        {
            Console.WriteLine("Connected");
            NetworkStream nStream = client.GetStream();
            try
            {
                nStream.Write(bStream, 0, bStream.Length);
            }
            catch (SocketException e1)
            {
                Console.WriteLine("SocketException: " + e1);
            }
        }
    }

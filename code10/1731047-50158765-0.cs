    TcpListener listener = new TcpListener(IPAddress.Any, 123);
    try
    {
        listener.Start();
        for (;;)
        {
            using (TcpClient client = await listener.AcceptTcpClientAsync())
            using (Stream stream = client.GetStream())
            {
                // Talk to client here.
            }
        }
    }
    finally
    {
        listener.Stop();
    }

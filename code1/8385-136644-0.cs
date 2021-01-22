    System.Net.Sockets.TcpClient client = new TcpClient();
    try
    {
        client.Connect(address, port);
        Console.WriteLine("Connection open, host active");
    } catch (SocketException ex)
    {
        Console.WriteLine("Connection could not be established due to: \n" + ex.Message);
    }
    finally
    {
        client.Close();
    }

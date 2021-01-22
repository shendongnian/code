    // .Connect throws an exception if unsuccessful
    client.Connect(anEndPoint);
    
    // This is how you can determine whether a socket is still connected.
    bool blockingState = client.Blocking;
    try
    {
        byte [] tmp = new byte[1];
    
        client.Blocking = false;
        client.Send(tmp, 0, 0);
        Console.WriteLine("Connected!");
    }
    catch (SocketException e) 
    {
        // 10035 == WSAEWOULDBLOCK
        if (e.NativeErrorCode.Equals(10035))
            Console.WriteLine("Still Connected, but the Send would block");
        else
        {
            Console.WriteLine("Disconnected: error code {0}!", e.NativeErrorCode);
        }
    }
    finally
    {
        client.Blocking = blockingState;
    }
    
     Console.WriteLine("Connected: {0}", client.Connected);

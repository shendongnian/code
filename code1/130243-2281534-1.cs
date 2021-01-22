    var timeToWait = TimeSpan.FromSeconds(10);
    
    var udpClient = new UdpClient( portNumber );
    var asyncResult = udpClient.BeginReceive( null, null );
    asyncResult.AsyncWaitHandle.WaitOne( timeToWait );
    try
    {
        IPEndPoint remoteEP = null;
        byte[] receivedData = udpClient.EndReceive( asyncResult, ref remoteEP );
        // EndReceive worked and we have received data and remote endpoint
    }
    catch (Exception ex)
    {
        // EndReceive failed and we ended up here
    }

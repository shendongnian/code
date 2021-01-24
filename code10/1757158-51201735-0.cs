    var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
    socket.Blocking = false;
    try
    {
    	socket.Connect("127.0.0.1", 12345);
    } 
    catch(SocketException se)
    {
    	//Ignore the "A non-blocking socket operation could not be completed immediately" error
    	if (se.ErrorCode != 10035)
    		throw;
    }
    
    //Check the connection status of the socket.
    var writeCheck = new List<Socket>() { socket };
    var errorCheck = new List<Socket>() { socket };
    Socket.Select(null, writeCheck, errorCheck, 0);
    
    if (writeCheck.Contains(socket)) 
    {
    	//Connection opened successfully.
    }
    else if (errorCheck.Contains(socket))
    {
    	//Connection refused
    }
    else
    {
    	//Connect still pending
    }

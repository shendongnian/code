    try
    {
    	// Listen for connections on port 13000
    	TcpListener server = new TcpListener(IPAddress.Loopback, 13000);
    	server.Start();
    
    	// Read up tp 256 bytes at a time 
    	Byte[] bytes = new Byte[256];
    	String data;
    
    	// Enter the listening loop. 
    	while (true)
    	{
    		Console.WriteLine("Waiting for a connection... ");
    
    		// Wait for a client connection
    		TcpClient client = server.AcceptTcpClient();
    		Console.WriteLine("Connected!");
    
    		// Setup I/O streams
    		NetworkStream stream = client.GetStream();
    		using (StreamWriter sw = new StreamWriter(stream))
    		{
    			int i;
    
    			// Loop to receive all the data sent by the client. 
    			while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
    			{
    				// Translate data bytes to a ASCII string. 
    				data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
    				Console.WriteLine(String.Format("Received: {0}", data));
    
    				// Process the data sent by the client. 
    				data = data.ToUpper();
    
    				// Send back a response. 
    				Console.WriteLine("Sending message..");
    				sw.Write(data);
    
    				// Add a little extra 'response'
    				sw.Write("<html><body>Hello There!</body></html>");
    				sw.Flush();
    			}
    		}
    		// Close connection 
    		client.Close();
    	}
    }
    catch (SocketException e)
    {
    	Console.WriteLine("SocketException: {0}", e);
    }

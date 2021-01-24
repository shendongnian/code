    public static void Data_IN(object cSocket)
    {      
      Socket clientSocket = (Socket)cSocket;
    
       byte[] Buffer;
       int readBytes;
    
        while (true)
        { 
    		try
    		{
    			Buffer = new byte[clientSocket.SendBufferSize];           
    			readBytes = clientSocket.Receive(Buffer);
    
    			if (readBytes > 0)
    			{
    				Packet p = new Packet(Buffer);
    				DataManager(p);
    			}
    		}catch(SocketException)
    		{
    			//handle closed connection
    		}
        }
    }

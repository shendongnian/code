    #region CHECKS THE SOCKET'S HEALTH
    	if (_tcpClient.Client.Connected)
    	{
    			//Do a ping test to see if the server is reachable
    			try
    			{
    				Ping pingTest = new Ping()
    				PingReply reply = pingTest.Send(ServeripAddress);
    				if (reply.Status != IPStatus.Success) ConnectionState = false;
    			} catch (PingException) { ConnectionState = false; }
    
    			//See if the tcp state is ok
    			if (_tcpClient.Client.Poll(5000, SelectMode.SelectRead) && (_tcpClient.Client.Available == 0))
    			{
    				ConnectionState = false;
    			}
    		}
    	}
    	else { ConnectionState = false; }
    #endregion

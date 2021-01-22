    void client_handler(Socket client) // set 'KeepAlive' true
    {
    	while (true)
    	{
    		try
    		{
    			if (client.Connected)
    			{
    
    			}
    			else
    			{ // client disconnected
    				break;
    			}
    		}
    		catch (Exception)
    		{
    			client.Poll(4000, SelectMode.SelectRead);// try to get state
    		}
    	}
    }

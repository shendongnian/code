    bool OK = false;
    Random Rnd = new Random();
    
    while(!OK)
    {
    	try
    	{
    		rows = Command.ExecuteNonQuery();
    		OK = true;
    	}
    	catch(Exception exDead)
    	{
    		if(exDead.Message.ToLower().Contains("deadlock"))
    			System.Threading.Thread.Sleep(Rnd.Next(1000, 5000));
    		else
    			throw exDead;
    	}
    }

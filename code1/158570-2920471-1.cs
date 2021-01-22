    public void DoTheJob()
    {
	int tries = 0;
    	try
    	{
    		using (var sr = new StreamReader(@"c:\lock.txt"))
    		{
    			try
    			{
    				// get the maximum code from my table
    				// generate next code
    				// update current record with the new code
    			}
    			catch (Exception ex)
    			{
    				Logger.WriteError(ex);
    			}
    			finally
    			{
    				sr.Close();
    			}
    		}
    	}
    	catch
    	{
    		Thread.Sleep(2000); // wait for lock for 2 second
		tries++;
		if (tries > 15)
			throw new Exception("Timeout, try again.");
    	}
    }

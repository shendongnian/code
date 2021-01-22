    // open the file with no sharing semantics (FileShare.None)
    using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
    {
    	try
    	{
    		stream.ReadByte();
    		return false;
    	}
    	catch (IOException ex)
    	{
    		// catch ONLY the exception we are interested in, and check the message too
    		if (ex.Message != null 
    			&& ex.Message.Contains("The process cannot access the file"));
    		{
    			return true;
    		}
    		
    		// if the message was incorrect, this was not the IOException we were looking for. Rethrow it.
    		throw;
        }
    }

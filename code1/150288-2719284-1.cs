    foreach (var file in files)
    {
    	try
    	{
    		// Save the file
    	}
    	catch (Exception e)
    	{
    		// Log exception
    		Console.WriteLine(e.Message);
    		// Do not re-throw the exception
    	}
    	continue;
    }

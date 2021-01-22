    //0 for false, 1 for true.
    private static int usingResource = 0;
    if (!EventLog.SourceExists(Constants.EventSrcPL))
    {
    	//0 indicates that the method is not in use.
    	if (0 == Interlocked.Exchange(ref usingResource, 1))
    	{
    		if (!EventLog.SourceExists(Constants.EventSrcPL))
    		{
    			try
    			{
    				EventLog.CreateEventSource(Constants.EventSrcPL, Constants.EventLogPL);
    			}
    			catch (Exception e)
    			{
    				System.Diagnostics.Debug.WriteLine(e.Message);
    			}
    			finally
    			{
    				//Release the lock
    				Interlocked.Exchange(ref usingResource, 0);
    			}
    		}
    	}
    }

    public static void KillPaint()
    {
    	System.Diagnostics.Process[] procs = null;
    
    	try
    	{
    		procs = Process.GetProcessesByName("calc");
    
    		Process mspaintProc = procs[0];
    
    		if (!mspaintProc.HasExited)
    		{
    			mspaintProc.Kill();
    		}
    	}
    	finally
    	{
    		if (procs != null)
    		{
    			foreach (Process p in procs)
    			{
    				p.Dispose();
    			}
    		}
    	}
    }

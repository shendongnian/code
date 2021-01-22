    private static StreamWriter sw;
    private static Queue<string> logQueue = new Queue<string>();
    public static string logLock = "";
    public static void LogLoop()
    {
    	sw = new StreamWriter("logFilePath.log"), true);
    	sw.AutoFlush = true;
    	while (true)
	    {
    		while (logQueue.Count > 0)
    		{
    			string s = "";
    			lock (logLock) // get a lock on the queue
    			{
    				s = logQueue.Dequeue();
    			}
    			sw.WriteLine(s);    			
    		}
    		Thread.Sleep(10);
    	}
    }
    public static void Log(string contents)
    {
    	contents = DateTime.Now.ToString("MM-dd-yy - HH:mm:ss ffff") + " - " + contents; // add a timestamp
    	lock (logLock) // get a lock on the queue
    	{
    		logQueue.Enqueue(contents);
    	}
    }

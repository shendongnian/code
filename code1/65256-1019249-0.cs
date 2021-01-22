    object myLock;
    
    void StartWorking()
    {
    	myLock = new object(); // only new it once, could be done in your constructor too.
    	for (int i = 0; i < Environment.Processorcount; i++)
    	{
    		ThreadPool.QueueUserWorkItem(null => DoWork());
    	}
    }
    
    void DoWork(object state)
    {
    	object task;
    	lock(myLock)
    	{
    		task = GetTaskFromDB();
    	}
    
    	PerformTask(task);
    }

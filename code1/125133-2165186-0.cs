    private AutoResetEvent ResetEvent { get; set; }
    
    LogMessage(string fullMessage)
    {
    	this.logQueue.Enqueue(fullMessage);
    
    	// Trigger the Reset Event to send the 
    	this.ResetEvent.Set();
    }
    
    private void ProcessQueueMessages()
    {
    	while (this.Running)
    	{
    		// This will process all the items in the queue.
    		while (this.logQueue.Count > 0)
    		{
    			// This method will just log the top item on the queue
    			this.LogQueueItem();
    		}
    
    		// Once the queue is empty will wait for a 
                // another message to queueed before running again.  
    		// Rather than sleeping and checking if the queue is full, 
                // saves from doing a System.Threading.Thread.Sleep(1000); stuff
    		this.ResetEvent.WaitOne();
    	}
    }

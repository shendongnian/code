	public Results[] Evaluate()
    {
        processingComplete = false;
		lock(lockobject) 
		{
        	resultQueue.Clear();
		}
        for (int i = 0; i < data.Length; ++i)
        {
            if (saveThread.ThreadState == ThreadState.Unstarted)
                saveThread.Start();
           //-....
           //Process data 
           // 
            lock (lockobject)
            {
                resultQueue.Enqueue(result);
            }
            signal.Set();
        }
        processingComplete = true;
    }
	
	private void SaveResults()
    {
        Model dataAccess = new Model();
		while (true)
        {
			int count;
			
			lock(lockobject)  
			{
				count = resultQueue.Count;
			}
            if (count == 0)
                signal.WaitOne();
			lock(lockobject)  
			{
				count = resultQueue.Count;
			}
			// we got a signal, but queue is empty, processing is complete
            if (count == 0)
                break;
			
			ModelResults result;
            lock (lockobject)
            {
                result = resultQueue.Dequeue();
            }
            dataAccess.Save(result);
        }
        SaveCompleteSignal.Set();
    }

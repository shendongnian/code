    while (keepgoing)
    { 
      List<Message> nextMsgs = new List<Message>();
      lock (messageQueue)
      {
        while (messageQueue.Count == 0)
        {
			try
			{
				Monitor.Wait(messageQueue);
			}
			catch(ThreadInterruptedException)
			{
				//...
			}
		}
        while (messageQueue.Count > 0)
        	nextMsgs.Add(messageQueue.DeQueue());
      }
      if(nextMsgs.Count > 0)
        ProcessMessages(nextMsgs);
    }

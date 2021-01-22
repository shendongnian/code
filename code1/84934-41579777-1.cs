    while (keepgoing)
    { 
      Message nextMsg;
      lock (messageQueue)
      {
        while (messageQueue.Count > 0)
          nextMsg= messageQueue.DeQueue();
      }
      if(nextMsg != null)
        ProcessMessages(nextMsg);
      else
        Monitor.Wait(messageQueue);
    }

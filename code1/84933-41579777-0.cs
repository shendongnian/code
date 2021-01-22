    while (keepgoing)
    { 
      Message nextMsg;
      lock (messageQueue)
      {
        while (messageQueue.Count > 0)
          message = messageQueue.DeQueue();
      }
      if(nextMsg != null)
        ProcessMessages(message);
      else
        Monitor.Wait(messageQueue);
    }

    while (keepgoing)
      { 
      lock (messageQueue)
          {
          while (messageQueue.Count > 0)
              ProcessMessages(messageQueue.DeQueue());
          Monitor.Wait(messageQueue);
          }
      }

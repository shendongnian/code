    var ts = new TimeSpan(0, 0, 10);
    MessageQueue q = GetQueue<T>();
    while (true)
    {
      try
      {
        Message msg = q.Receive(ts);
        var t = (T)msg.Body;
        HandleMessage(t);
      }
      catch (MessageQueueException e)
      {
        // Test to see if this was just a timeout.
        // If it was, just continue, there were no msgs waiting
        // If it wasn't, something horrible may have happened
      }
    }

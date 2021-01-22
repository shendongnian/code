    static Message GetQueueMessage(MessageQueue queue)
    {
      // Store the current time.
      DateTime now = DateTime.Now;
    
      // Get the message on top of the queue.
      Message message = queue.Peek();
    
      // If the current time is greater than or equal to 20 minutes, then process it,
      // otherwise, get out and return false.  Generate 20 minutes first.
      // You can refactor this to have it passed in.
      TimeSpan delay = TimeSpan.FromMinutes(20);
    
      // If the delay is greater than the arrived time and now, then get out.
      if (delay > (now - message.ArrivedTime))
      {
        // Return null.
        return null;
      }
    
      // Pop the message from the queue to remove it.
      return queue.ReceiveById(message.Id);    
    }

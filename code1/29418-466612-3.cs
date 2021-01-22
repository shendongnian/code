    // Have some other reasonable check here.
    do while (true)
    {
      // The message to process.
      Message message = GetQueueMessage(queue);
    
      // Continue to process while there is a message.
      do while (message != null)
      {
        // Process the message.
    
        // Get the next message.
        message = GetQueueMessage(queue);
      }
    
      // Wait a little bit, five seconds for example.
      Thread.Sleep(5000);
    }

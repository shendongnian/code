    // New file
    // Create an alias
    using Message = Union<ClearMessage, TryDequeueMessage, EnqueMessage>;
    int ProcessMessage(Message msg)
    {
       return Message.Match(
          clear => 1,
          dequeue => 2,
          enqueue => 3);
    }
    

    // TC message queue manager, sends messages
    public class TaskMessageQueueManager
    {
      public void NotifySubscribersOfNewTasks()
      {
        var queue = getQueue(".\private$\TaskNotifications");
        queue.Send("Tasks waiting.");
      }
    
      private MessageQueue getQueue(string name)
      {
        MessageQueue queue = null;
        try
        {
          if (!MessageQueue.Exists(name))
          {
            queue = MessageQueue.Create(name);
          }
          else
          {
            queue = new MessageQueue(name);
          }
        } 
        catch (Exception ex)
        {
          throw new InvalidOperationException("An error occurred while retrieving the message queue '" + name + "'.", ex);
        }
    
        return queue;
      }
    }
    
    // TP message queue handler, receives messages
    public class TaskMessageQueueHandler
    {
      private Thread m_thread;
      private ManualResetEvent m_signal;
    
      public void Start()
      {
        m_signal = new ManualResetEvent(false);
        m_thread = new Thread(MSMQReceiveLoop);
        m_thread.Start();
        
      }
    
      public void Stop()
      {
        m_signal.Set();
      }
    
      private void MSMQReceiveLoop()
      {
        bool running = true;
        MessageQueue queue = getQueue(".\private$\TaskNotifications");
    
        while (running)
        {
          try
          {
            var message = queue.Receive(); // Blocks here until a message is received by MSMQ
    
            if (message.Body.ToString() == "Tasks waiting.")
            {
              // TODO: Fire off process, perhaps another thread, to handle waiting tasks
            }
            if (m_signal.WaitOne(10)) // Non-blocking check for exit signal
            {
              running = false; // If Stop method has been called, the signal will be set and we can end loop
            } 
          }
          catch
          {
             // handle error
             running = false;
          }
        }
      }
    }

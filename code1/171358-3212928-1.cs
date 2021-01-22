    public class YourClass
    {
      private BlockingQueue<ProcessData> m_Queue = new BlockingQueue<ProcessData();
    
      private void ProcessLoop()
      {
        while (true)
        {
          ProcessData item = m_Queue.Dequeue();
          if (HasPriority(item))
          {
            Process(item);
          }
        }
      }
    
      public void AddProcessData(ProcessData item)
      {
        m_Queue.Enqueue(item);
      }
      public void Startup()
      {
        var thread = new Thread(() => { ProcessLoop(); });
        thread.Start();
      }
    }

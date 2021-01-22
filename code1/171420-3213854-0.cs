    public class Worker
    {
      private BlockingQueue<Message> m_Queue = new BlockingQueue<Message>();
    
      public void Start()
      {
        var fetcher = new Thread(() => { Fetch(); });
        var processor = new Thread(() => { Process(); });
        fetcher.Start();
        processor.Start();
      }
    
      public void Fetch()
      {
         bool finished = false;
         while (!finished)
         {
           var packet = GetDataPacketFromDatabase();
           var message = new Message();
           message.Packet = packet;
           m_Queue.Enqueue(message);
         }
      }
    
      public void Process()
      {
        while (true)
        {
          Message message = m_Queue.Dequeue();
          if (message.Packet 1= null)
          {
            Accumulate(message.Packet);
          }
          else
          {
            break; // Stop if there is nothing left to accumulate.
          }
        }
      }
    
      private void Accumulate(Packet p)
      {
        // Process the packet and accumulate the results.
      }
    }

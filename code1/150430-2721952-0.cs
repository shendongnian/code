    public class Example
    {
      private BlockingQueue<Task> m_Queue = new BlockingQueue<Task>();
    
      public void StartExample()
      {
        Thread producer = new Thread(() => Producer());
        Thread consumer = new Thread(() => Consumer());
        producer.Start();
        consumer.Start();
        producer.Join();
        consumer.Join();
      }
    
      private void Producer()
      {
        for (int i = 0; i < 10; i++)
        {
          m_Queue.Enqueue(new Task());
        }
      }
    
      private void Consumer()
      {
        while (true)
        {
          Task task = m_Queue.Dequeue();
        }
      }
    }

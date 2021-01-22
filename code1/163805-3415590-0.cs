    public class Program
    {
      private static BlockingQueue<string> m_Queue = new BlockingQueue<string>();
    
      public static void Main()
      {
        var thread1 = new Thread(Process);
        var thread2 = new Thread(Process);
        thread1.Start();
        thread2.Start();
        while (true)
        {
          string url = GetNextUrl();
          m_Queue.Enqueue(url);
        }
      }
    
      public static void Process()
      {
        while (true)
        {
          string url = m_Queue.Dequeue();
          // Do whatever with the url here.
        }
      }
    }

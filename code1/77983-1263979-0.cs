    public MyService : IMyService
    {
         public static Queue queue = new Queue();
         public void SendMessage(string from, string to, string message)
         {
              Queue syncQueue = Queue.Synchronized(queue);
              syncQueue.Enqueue(new Message(from, to, message));
         }
    }

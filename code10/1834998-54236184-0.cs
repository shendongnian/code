    public class ApiController
    {
      private Queue<string> queue = new Queue<string>();
      private object sync = new object();
      
      public ApiController()
      {
        // create a thread here or on web app start
      }
      
      private void ThreadProc()
      {
        while (true)
        {
          string filename = null;
          lock (sync)
          {
            if (queue.Count() > 0)
              filename = queue.Dequeue();
          }
          
          if (filename != null)
          {
            // create process
          }
          else
          {
            Thread.Sleep(100);
            continue;
          }
        }
      }
      
      public void ApiMethod()
      {
        // save file from request stream and pass name of this file to thread
        string filename = ...
        lock (sync)
          queue.Enqueue(filename);
      }
    }

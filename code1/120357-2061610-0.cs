    BlockingQueue q = new BlockingQueue();
    
      void ProducerThread()
      {
        while (!done)
          {
            MyData d = GetData();
            q.Enqueue(d);
            Thread.Sleep(100);
         }
      }
    
      void ConsumerThread()
      {
        while (!done)
          {
            MyData d = (MyData)q.Dequeue();
            process(d);
          }
      }

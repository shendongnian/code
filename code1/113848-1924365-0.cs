    void myWorkerProcess(object state) {
       WorkItem workItem;
    
       while (!m_Terminate) {
          m_Event.WaitOne(5000);
          if (m_Queue.Count > 0) {
             lock (m_Queue) workItem = m_Queue.Dequeue();
             // ... do your single threaded operation here ...
          }
       }
    }

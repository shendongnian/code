    ManualResetEvent m_Cancel = new ManualResetEvent(false);
    CancellableBlockingCollection<object> m_Queue = new CancellableBlockingCollection<object>();
    
    private void ConsumerThread()
    {
      while (true)
      {
        object item = m_Queue.Take(m_Cancel); // This will throw if the event is signalled.
      }
    }

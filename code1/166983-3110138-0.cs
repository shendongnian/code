    public class Worker
    {
      private Object m_LockObject = new Object();
    
      public bool IsWorking
      {
        get { return Monitor.TryEnter(m_LockObject, 0); }
      }
    
      public void LaunchProcess()
      {
        lock (m_LockObject)
        {
          DoExpansiveProcess();
        }
      }
    }

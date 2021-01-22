    public class Worker
    {
      private Object m_LockObject = new Object();
      private volatile bool m_IsWorking = false;
    
      public bool IsWorking
      {
        get { return m_IsWorking; }
      }
    
      public void LaunchProcess()
      {
        lock (m_LockObject)
        {
          m_IsWorking = true;
          DoExpansiveProcess();
          m_IsWorking = false;
        }
      }
    }

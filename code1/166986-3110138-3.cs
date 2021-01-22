    public class Worker
    {
      private Semaphore m_Semaphore = new Semaphore(1, 1);
    
      public bool IsWorking
      {
        get { return !m_Semaphore.WaitOne(0); }
      }
    
      public void LaunchProcess()
      {
        m_Semaphore.WaitOne();
        try
        {
          DoExpansiveProcess();
        }
        finally
        {
          m_Semaphore.Release();
        }
      }
    }

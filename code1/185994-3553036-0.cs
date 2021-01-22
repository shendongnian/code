    public class Example
    {
      private CountdownEvent m_Finisher = new CountdownEvent(0);
    
      public void MainThread()
      {
        m_Finisher.AddCount();
    
        // Your stuff goes here.
        // myListener.BeginAcceptSocket(OnAcceptSocket, null);
    
        m_Finisher.Signal();
        m_Finisher.Wait();
      }
    
      private void OnAcceptSocket(object state)
      {
        m_Finisher.AddCount()
        try
        {
          // Your stuff goes here.
        }
        finally
        {
          m_Finisher.Signal();
        }
      }
    }

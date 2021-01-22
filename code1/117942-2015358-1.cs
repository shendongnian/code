    public class TheConsumer : IDisposable
    {
      void Dispose()
      {
         if(m_FontCreator != null)
              m_FontCreator.Dispose();
      }
    }

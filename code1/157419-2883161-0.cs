    public class Program
    {
      private static SharedLock m_Lock = new SharedLock();
    
      public static void SomeThreadMethod()
      {
        using (m_Lock.Acquire())
        {
        }
      }
    }
    
    public sealed class SharedLock
    {
      private Object m_LockObject = new Object();
    
      public SharedLock()
      {
      }
    
      public IDisposable Acquire()
      {
        return new LockToken(this);
      }
    
      private sealed class LockToken : IDisposable
      {
        private readonly SharedLock m_Parent;
    
        public LockToken(SharedLock parent)
        {
          m_Parent = parent;
          Monitor.Enter(parent.m_LockObject);
        }
    
        public void Dispose()
        {
          Monitor.Exit(m_Parent.m_LockObject);
        }
      }
    }

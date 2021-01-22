    public class SingletonWCFProxyLifestyleManager : LifetimeManager, IRequiresRecovery, IDisposable
       {
          private static readonly object _locker = new object();
          private Guid _key;
    
          public SingletonWCFProxyLifestyleManager()
          {
             _key = Guid.NewGuid(); 
          }
    
          public override object GetValue()
          {
             Monitor.Enter(_locker);
             object result = Storage.Instance.Get(_key);
             if (result != null)
             {
                ICommunicationObject communicationObject = result
                                                           as ICommunicationObject;
                //If the proxy is in faulted state, it's aborted and a new proxy is created
                if (communicationObject != null &&
                    communicationObject.State == CommunicationState.Faulted)
                {
                   try
                   {
                      communicationObject.Abort();
                   }
                   catch
                   {
                   }
    
                   Dispose();
                   return null;   //Return before releasing monitor
                }
                Monitor.Exit(_locker);
             }
             return result;
          }
    
          public override void RemoveValue()
          {
             
          }
    
          public override void SetValue(object newValue)
          {
             Storage.Instance.Set(_key, newValue);
             TryToReleaseMonitor(); 
          }
    
          #region IRequiresRecovery Members
    
          public void Recover()
          {
             TryToReleaseMonitor();
          }
    
          #endregion
    
          private void TryToReleaseMonitor()
          {
             try
             {
                Monitor.Exit(_locker);
             }
             catch(SynchronizationLockException)
             {
             } // This is ok, just means we don't hold the lock
          }
    
          #region IDisposable Members
    
          public void Dispose()
          {
             object result = Storage.Instance.Get(_key);
             if (result != null)
             {
                try
                {
                   Storage.Instance.RemoveAndDispose(_key);
                }
                catch
                {
                   ICommunicationObject communicationObject = result as ICommunicationObject;
                   if (communicationObject != null)
                   {
                      communicationObject.Abort();
                   }
                }
             }
          }
    
          #endregion
       }

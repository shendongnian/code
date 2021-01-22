    public class ThreadsGettinCrazy {
      static readonly _sync = new object();
      static bool _threadCReady = false;
    
      public void ThreadA() {
        lock(_sync) {
          while (true) {
            // do work, possibly set _threadCReady = true
            Monitor.Pulse(_sync);
            if (/* i'm done */) break;
            Monitor.Wait(_sync);
          }
        }
      }
    
      public void ThreadB() {
        lock(_sync) {
          while (true) {
            while(/* i'm not ready */) {
              Monitor.Pulse(_sync);
              Monitor.Wait(_sync);
            }
            // do work, possibly set _threadCReady = true
            Monitor.Pulse(_sync);
            if (/* i'm done */) break;
            Monitor.Wait(_sync);
          }
        }
      }
    
      public void ThreadC() {
        lock(sync) {
          while (!_threadCReady) {
            Monitor.Pulse();
            Monitor.Wait();
          }
          // do work
        }
      }
    }

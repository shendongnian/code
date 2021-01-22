    public class ThreadsGettinCrazy {
      static readonly _sync = new object();
      static bool _threadCReady = false;
    
      public void ThreadA() {
        while (true) {
          lock(_sync) {
            while(/* my condition not met */) {
              Monitor.PulseAll(_sync);
              Monitor.Wait(_sync);
            }
            // do work, possibly set _threadCReady = true
            Monitor.PulseAll(_sync);
          }
          if (/* i'm done */) break;
        }
      }
    
      public void ThreadB() {
        while (true) {
          lock(_sync) {
            while(/* my condition not met */) {
              Monitor.PulseAll(_sync);
              Monitor.Wait(_sync);
            }
            // do work, possibly set _threadCReady = true
            Monitor.PulseAll(_sync);
          }
          if (/* i'm done */) break;
        }
      }
    
      public void ThreadC() {
        lock(_sync) {
          while (!_threadCReady) {
            Monitor.PulseAll(_sync);
            Monitor.Wait(_sync);
          }
          // do work
        }
      }
    }

    // A simple thread pool implementation that provides STA threads instead of the MTA threads provided by the built-in thread pool
    public class STAThreadPool
    {
      int _maxThreads;
      int _startedThreads;
      int _idleThreads;
      Queue<Action> _workQueue = new Queue<Action>();
      public STAThreadPool(int maxThreads)
      {
        _maxThreads = maxThreads;
      }
      void Run()
      {
        while(true)
          try
          {
            Action action;
            lock(_workQueue)
            {
              _idleThreads++;
              while(_workQueue.Count==0)
                Monitor.Wait(_workQueue);
              action = _workQueue.Dequeue();
              _idleThreads++;
            }
            action();
          }
          catch(Exception ex)
          {
            System.Diagnostics.Trace.Write("STAThreadPool thread threw exception " + ex);
          }
      }
      public void QueueWork(Action action)
      {
        lock(_workQueue)
        {
          if(_startedThreads < _maxThreads && _idleThreads <= _workQueue.Count)
            new Thread(Run) { ApartmentState = ApartmentState.STA, IsBackground = true, Name = "STAThreadPool#" + ++_startedThreads }.Start();
          _workQueue.Enqueue(action);
          Monitor.PulseAll(_workQueue);
        }
      }
      public void InvokeOnPoolThread(Action action)
      {
        Exception exception = null;
        using(ManualResetEvent doneEvent = new ManualResetEvent(false))  // someday:  Recycle these events
        {
          QueueWork(delegate
          {
            try { action(); } catch(Exception ex) { exception = ex; }
            doneEvent.Set();
          });
          doneEvent.WaitOne();
        }
        if(exception!=null)
          throw exception;
      }
      public T InvokeOnPoolThread<T>(Func<T> func)
      {
        T result = default(T);
        InvokeOnPoolThread(delegate
        {
          result = func();
        });
        return result;
      }
    }

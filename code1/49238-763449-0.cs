    using System;
    using System.Threading;
    
    class MyAsyncResult : IAsyncResult
    {
        object _state;
        object _lock = new object();
        ManualResetEvent _doneEvent = new ManualResetEvent(false);
        AsyncCallback _callback;
        Exception _ex;
        bool _done;
        int _result;
        int _x;
        
        public MyAsyncResult(int x, AsyncCallback callback, object state)
        {
            _callback = callback;
            _state = state;
            _x = x; // arbitrary argument(s)
        }
        
        public int X { get { return _x; } }
        
        public void SignalDone(int result)
        {
            lock (_lock)
            {
                _result = result;
                _done = true;
                _doneEvent.Set();
            }
            // never invoke any delegate while holding a lock
            if (_callback != null)
                _callback(this); 
        }
        
        public void SignalException(Exception ex)
        {
            lock (_lock)
            {
                _ex = ex;
                _done = true;
                _doneEvent.Set();
            }
            if (_callback != null)
                _callback(this);
        }
        
        public object AsyncState
        {
            get { return _state; }
        }
        
        public WaitHandle AsyncWaitHandle
        {
            get { return _doneEvent; }
        }
        
        public bool CompletedSynchronously
        {
            get { return false; }
        }
        
        public int Result
        {
            // lock (or volatile, complex to explain) needed
            // for memory model problems.
            get
            {
                lock (_lock)
                {
                    if (_ex != null)
                        throw _ex;
                    return _result;
                }
            }
        }
        
        public bool IsCompleted
        {
            get { lock (_lock) return _done; }
        }
    }
    
    class Program
    {
        static void MyTask(object param)
        {
            MyAsyncResult ar = (MyAsyncResult) param;
            try
            {
                int x = ar.X;
                Thread.Sleep(1000); // simulate lengthy work
                ar.SignalDone(x * 2); // demo work = double X
            }
            catch (Exception ex)
            {
                ar.SignalException(ex);
            }
        }
        
        static IAsyncResult Begin(int x, AsyncCallback callback, object state)
        {
            Thread th = new Thread(MyTask);
            MyAsyncResult ar = new MyAsyncResult(x, callback, state);
            th.Start(ar);
            return ar;
        }
        
        static int End(IAsyncResult ar)
        {
            MyAsyncResult mar = (MyAsyncResult) ar;
            mar.AsyncWaitHandle.WaitOne();
            return mar.Result; // will throw exception if one 
                               // occurred in background task
        }
        
        static void Main(string[] args)
        {
            // demo calling code
            // we don't need state or callback for demo
            IAsyncResult ar = Begin(42, null, null); 
            int result = End(ar);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

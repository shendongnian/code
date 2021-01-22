        static void Main()
        {
            DoWork(OK, 5000);
            DoWork(Nasty, 5000);
        }
        static void OK()
        {
            Thread.Sleep(1000);
        }
        static void Nasty()
        {
            Thread.Sleep(10000);
        }
        static void DoWork(Action action, int timeout)
        {
            ManualResetEvent evt = new ManualResetEvent(false);
            AsyncCallback cb = delegate {evt.Set();};
            IAsyncResult result = action.BeginInvoke(cb, null);
            if (evt.WaitOne(timeout))
            {
                action.EndInvoke(result);
            }
            else
            {
                throw new TimeoutException();
            }
        }
        static T DoWork<T>(Func<T> func, int timeout)
        {
            ManualResetEvent evt = new ManualResetEvent(false);
            AsyncCallback cb = delegate { evt.Set(); };
            IAsyncResult result = func.BeginInvoke(cb, null);
            if (evt.WaitOne(timeout))
            {
                return func.EndInvoke(result);
            }
            else
            {
                throw new TimeoutException();
            }
        }

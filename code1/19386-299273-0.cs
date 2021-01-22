    class Program
    {
        static void Main(string[] args)
        {
            CallWithTimeout(NotTooLong, 9000);
            CallWithTimeout(TooLong, 9000);
        }
        static void TooLong()
        {
            Thread.Sleep(10000);
        }
        static void NotTooLong()
        {
            Thread.Sleep(8000);
        }
        static void CallWithTimeout(Action action, int timeoutMilliseconds)
        {
            Thread threadToKill = null;
            Action wrappedAction = new Action(delegate()
            {
                threadToKill = Thread.CurrentThread;
                try
                {
                    action();
                }
                catch (ThreadAbortException)
                {
                    //a rare instance where we really don't handle an exception
                }
            });
            IAsyncResult result = wrappedAction.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
            {
                wrappedAction.EndInvoke(result);
            }
            else
            {
                threadToKill.Abort();
                throw new TimeoutException();
            }
        }
    }

    static class AsyncUtils
    {
        static public void DelayCall(int msec, Action fn)
        {
            // Grab the dispatcher from the current executing thread
            Dispatcher d = Dispatcher.CurrentDispatcher;
            // Tasks execute in a thread pool thread
            new Task (() => {
                System.Threading.Thread.Sleep (msec);   // delay
                // use the dispatcher to asynchronously invoke the action 
                // back on the original thread
                d.BeginInvoke (fn);                     
            }).Start ();
        }
    }

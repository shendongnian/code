    class Program
    {
        public static class Test
        {
            public static string DoThis()
            {
                lock (typeof(Test))
                {
                    return "got it!";
                }
            }
        }
        public delegate string Something();
        static void Main(string[] args)
        {
            Something call =Test.DoThis;
            //Holding lock from _outside_ the class
            IAsyncResult async;
            lock (typeof(Test))
            {
                //Calling method on another thread.
                async = call.BeginInvoke(null, null);
            }
            async.AsyncWaitHandle.WaitOne();
            string result = call.EndInvoke(async);
            lock (typeof(Test))
            {
                async = call.BeginInvoke(null, null);
                async.AsyncWaitHandle.WaitOne();
            }
            result = call.EndInvoke(async);
        }
    }

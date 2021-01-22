    class Program
    {
        public class Test
        {
            public string DoThis()
            {
                lock (this)
                {
                    return "got it!";
                }
            }
        }
        public delegate string Something();
        static void Main(string[] args)
        {
            var test = new Test();
            Something call = test.DoThis;
            //Holding lock from _outside_ the class
            IAsyncResult async;
            lock (test)
            {
                //Calling method on another thread.
                async = call.BeginInvoke(null, null);
            }
            async.AsyncWaitHandle.WaitOne();
            string result = call.EndInvoke(async);
            lock (test)
            {
                async = call.BeginInvoke(null, null);
                async.AsyncWaitHandle.WaitOne();
            }
            result = call.EndInvoke(async);
        }
    }

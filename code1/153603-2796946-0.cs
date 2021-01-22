     public static void Extension<T>(this T self, AsyncCallback callback )
        {
            var state = new State { callback = callback };
            System.Threading.ThreadPool.QueueUserWorkItem(ExtensionCore, callback);
        }
        private static void ExtensionCore(object state)
        {
            // do stuff with OtherStuff
            var complete = new Complete();
            ((State)state).callback(complete);
        }
        private class State
        {
            public AsyncCallback callback { get; set; }
            public object OtherStuff { get; set; }
        }
        public class Complete : IAsyncResult 
        {  
            public object AsyncState
            {
                get { throw new NotImplementedException(); }
            }
            public System.Threading.WaitHandle AsyncWaitHandle
            {
                get { throw new NotImplementedException(); }
            }
            public bool CompletedSynchronously
            {
                get { throw new NotImplementedException(); }
            }
            public bool IsCompleted
            {
                get { throw new NotImplementedException(); }
            }
        }
    }

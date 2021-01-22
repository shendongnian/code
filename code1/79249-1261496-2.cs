    namespace ConsoleApplication1
    {
        class Program
        {
            private static WaitHandle[] waitHandles;
            private static event EventHandler Evt1;
            private static event EventHandler Evt2;
    
            static void Main(string[] args)
            {
                waitHandles = new WaitHandle[]{
                     new ManualResetEvent(false),
                     new ManualResetEvent(false)
                };
    
                var callabck1 = new AsyncCallback(OnEvt1);
                var callabck2 = new AsyncCallback(OnEvt2);
    
                callabck1.Invoke(new ManualResetResult(null, (ManualResetEvent)waitHandles[0]));
                callabck2.Invoke(new ManualResetResult(null, (ManualResetEvent)waitHandles[1]));
    
                WaitHandle.WaitAll(waitHandles);
    
                Console.WriteLine("Finished");
                Console.ReadLine();
    
            }
    
            static void OnEvt1(IAsyncResult result)
            {
                Console.WriteLine("Setting1");
                var handle = result.AsyncWaitHandle;
                ((ManualResetEvent)handle).Set();
            }
    
            static void OnEvt2(IAsyncResult result)
            {
                Thread.Sleep(2000);
                Console.WriteLine("Setting2");
                var handle = result.AsyncWaitHandle;
                ((ManualResetEvent)handle).Set();
            }
    
        }
    
        public class ManualResetResult : IAsyncResult
        {
            private object _state;
            private ManualResetEvent _handle;
    
            public ManualResetResult(object state, ManualResetEvent handle)
            {
                _state = state;
                _handle = handle;
            }
    
            #region IAsyncResult Members
    
            public object AsyncState
            {
                get { return _state; }
            }
    
            public WaitHandle AsyncWaitHandle
            {
                get { return _handle; }
            }
    
            public bool CompletedSynchronously
            {
                get { throw new NotImplementedException(); }
            }
    
            public bool IsCompleted
            {
                get { throw new NotImplementedException(); }
            }
    
            #endregion
        }
    }

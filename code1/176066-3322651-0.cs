    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    namespace Commons.CLI.Sandbox
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myMain = new Program();
                myMain.Run();
                
                Console.WriteLine("Result: " + myMain.Output["start"] + " on thread: " + Thread.CurrentThread.ManagedThreadId);
                Console.ReadKey();
            }
    
            public IDictionary<string, int> Output { get; set; }
            private object _outputLock = new object();
    
            private DoSomethingResultRetriever _methodToCall;
            
            private ManualResetEvent _waiter;
    
            public void Run()
            {
                _waiter = new ManualResetEvent(false);
    
                _methodToCall = DoSomething;
                var asyncResult = BeginDoSomething("start");
    
                // We need to wait for the other thread to run
                Console.WriteLine(String.Format("Thread {0} is about to wait.", Thread.CurrentThread.ManagedThreadId));
    
                // Do other things ...
    
                if (asyncResult.IsCompleted) return;
                
                _waiter.WaitOne();
            }
    
            private IAsyncResult BeginDoSomething(string startsWith)
            {
                return _methodToCall.BeginInvoke(startsWith, EndDoSomething, null);
            }
    
            private void EndDoSomething(IAsyncResult ar)
            {
                lock (_outputLock)
                {
                    Output = _methodToCall.EndInvoke(ar);
                }
    
                _waiter.Set();
            }
    
            private delegate IDictionary<string, int> DoSomethingResultRetriever(string startsWith);
    
            private IDictionary<string, int> DoSomething(string startsWith)
            {
                Console.WriteLine("DoSomething on thread: " + Thread.CurrentThread.ManagedThreadId);
                return new Dictionary<string, int>() { { startsWith, 10 } };
            }
        }
    }

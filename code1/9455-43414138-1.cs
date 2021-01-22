    using System;
    using System.Threading;
    
    namespace ConsoleApplicationDotNetBasics.ThreadingExamples
    {
        public class AutoResetEventSample
        {
            private readonly AutoResetEvent _autoReset = new AutoResetEvent(false);
    
            public void RunAll()
            {
                new Thread(Worker1).Start();
                new Thread(Worker2).Start();
                new Thread(Worker3).Start();
                Console.WriteLine("All Threads Scheduled to RUN!. ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Main Thread is waiting for 15 seconds, observe 3 thread behaviour. All threads run once and stopped. Why? Because they call WaitOne() internally. They will wait until signals arrive, down below.");
                Thread.Sleep(15000);
                Console.WriteLine("1- Main will call AutoResetEvent.Set() in 5 seconds, watch out!");
                Thread.Sleep(5000);
                _autoReset.Set();
                Thread.Sleep(2000);
                Console.WriteLine("2- Main will call AutoResetEvent.Set() in 5 seconds, watch out!");
                Thread.Sleep(5000);
                _autoReset.Set();
                Thread.Sleep(2000);
                Console.WriteLine("3- Main will call AutoResetEvent.Set() in 5 seconds, watch out!");
                Thread.Sleep(5000);
                _autoReset.Set();
                Thread.Sleep(2000);
                Console.WriteLine("4- Main will call AutoResetEvent.Reset() in 5 seconds, watch out!");
                Thread.Sleep(5000);
                _autoReset.Reset();
                Thread.Sleep(2000);
                Console.WriteLine("Nothing happened. Why? Becasuse Reset Sets the state of the event to nonsignaled, causing threads to block. Since they are already blocked, it will not affect anything.");
                Thread.Sleep(10000);
                Console.WriteLine("This will go so on. Everytime you call Set(), AutoResetEvent will let another thread to run. It will make it automatically, so you do not need to worry about thread running order, unless you want it manually!");
                Thread.Sleep(5000);
                Console.WriteLine("Main thread reached to end! ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
    
            }
    
            public void Worker1()
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine("Worker1 is running {0}/5. ThreadId: {1}.", i, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(500);
                    // this gets blocked until _autoReset gets signal
                    _autoReset.WaitOne();
                }
                Console.WriteLine("Worker1 is DONE. ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
            }
            public void Worker2()
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine("Worker2 is running {0}/5. ThreadId: {1}.", i, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(500);
                    // this gets blocked until _autoReset gets signal
                    _autoReset.WaitOne();
                }
                Console.WriteLine("Worker2 is DONE. ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
            }
            public void Worker3()
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine("Worker3 is running {0}/5. ThreadId: {1}.", i, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(500);
                    // this gets blocked until _autoReset gets signal
                    _autoReset.WaitOne();
                }
                Console.WriteLine("Worker3 is DONE. ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
    
    }

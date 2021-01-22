    using System;
    using System.Threading;
    
    namespace ConsoleApplicationDotNetBasics.ThreadingExamples
    {
        public class ManualResetEventSample
        {
            private readonly ManualResetEvent _manualReset = new ManualResetEvent(false);
    
            public void RunAll()
            {
                new Thread(Worker1).Start();
                new Thread(Worker2).Start();
                new Thread(Worker3).Start();
                Console.WriteLine("All Threads Scheduled to RUN!. ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Main Thread is waiting for 15 seconds, observe 3 thread behaviour. All threads run once and stopped. Why? Because they call WaitOne() internally. They will wait until signals arrive, down below.");
                Thread.Sleep(15000);
                Console.WriteLine("1- Main will call ManualResetEvent.Set() in 5 seconds, watch out!");
                Thread.Sleep(5000);
                _manualReset.Set();
                Thread.Sleep(2000);
                Console.WriteLine("2- Main will call ManualResetEvent.Set() in 5 seconds, watch out!");
                Thread.Sleep(5000);
                _manualReset.Set();
                Thread.Sleep(2000);
                Console.WriteLine("3- Main will call ManualResetEvent.Set() in 5 seconds, watch out!");
                Thread.Sleep(5000);
                _manualReset.Set();
                Thread.Sleep(2000);
                Console.WriteLine("4- Main will call ManualResetEvent.Reset() in 5 seconds, watch out!");
                Thread.Sleep(5000);
                _manualReset.Reset();
                Thread.Sleep(2000);
                Console.WriteLine("It ran one more time. Why? Even Reset Sets the state of the event to nonsignaled (false), causing threads to block, this will initial the state, and threads will run again until they WaitOne().");
                Thread.Sleep(10000);
                Console.WriteLine();
                Console.WriteLine("This will go so on. Everytime you call Set(), ManualResetEvent will let ALL threads to run. So if you want synchronization between them, consider using AutoReset event, or simply user TPL (Task Parallel Library).");
                Thread.Sleep(5000);
                Console.WriteLine("Main thread reached to end! ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
    
            }
    
            public void Worker1()
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("Worker1 is running {0}/10. ThreadId: {1}.", i, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(5000);
                    // this gets blocked until _autoReset gets signal
                    _manualReset.WaitOne();
                }
                Console.WriteLine("Worker1 is DONE. ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
            }
            public void Worker2()
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("Worker2 is running {0}/10. ThreadId: {1}.", i, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(5000);
                    // this gets blocked until _autoReset gets signal
                    _manualReset.WaitOne();
                }
                Console.WriteLine("Worker2 is DONE. ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
            }
            public void Worker3()
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("Worker3 is running {0}/10. ThreadId: {1}.", i, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(5000);
                    // this gets blocked until _autoReset gets signal
                    _manualReset.WaitOne();
                }
                Console.WriteLine("Worker3 is DONE. ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
    
    }

    using System;
    using System.Threading;
    namespace MonitorWait
    {
        class Program
        {
            private static readonly object somelock = new object();
            static void Main(string[] args)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(SyncCall));
                Thread.Sleep(5000);  //Give the SyncCall a chance to run...
                //Thread.Sleep(6000);  //Uncomment to see it timeout.
                lock (somelock)
                {
                    Monitor.Pulse(somelock);  //Tell the SyncCall it can wake up...
                }
                Thread.Sleep(1000);  //Pause the main thread so the other thread 
                                     //prints before this one :)
                Console.WriteLine("Press the any key...");
                Console.ReadKey();
            }
            private static void SyncCall(object o)
            {
                lock (somelock)
                {
                    Console.WriteLine("Waiting with a 10 second timeout...");
                    bool ret = Monitor.Wait(somelock, 10000);
                    if (ret)
                    {
                        Console.WriteLine("Pulsed...");
                    }
                    else
                    {
                        Console.WriteLine("Timed out...");
                    }
                }
            }
        }
    }

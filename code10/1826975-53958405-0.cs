    using System;
    using System.Threading;
    
    static public class Test
    {
        static public ManualResetEvent isDoneEvent;
    
        static Test()
        {
            isDoneEvent = new ManualResetEvent (false);
            Thread a = new Thread(TestThread);
            a.Priority = ThreadPriority.Highest;
            a.Start();
    
            while (!isDoneEvent.WaitOne(1)); //Wait with a time-out to avoid blocking
    
            Console.WriteLine("True");
        }
    
        static private void TestThread()
        {
            isDoneEvent.Set()
        }
    }

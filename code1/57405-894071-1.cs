    using System;
    using System.Threading;
    
    namespace ConsoleApplication7
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                LockableClass lockable = new LockableClass();
                new Thread(new ParameterizedThreadStart(BackgroundMethod)).Start(lockable);
                Thread.Sleep(500);
                Console.Out.WriteLine("calling Reset");
                lockable.Reset();
            }
    
            private static void BackgroundMethod(Object lockable)
            {
                lock (lockable)
                {
                    Console.Out.WriteLine("background thread got lock now");
                    Thread.Sleep(Timeout.Infinite);
                }
            }
        }
    
        public class LockableClass
        {
            public Int32 Value1 { get; set; }
            public Int32 Value2 { get; set; }
    
            public void Reset()
            {
                Console.Out.WriteLine("attempting to lock on object");
                lock (this)
                {
                    Console.Out.WriteLine("main thread got lock now");
                    Value1 = 0;
                    Value2 = 0;
                }
            }
        }
    
    }

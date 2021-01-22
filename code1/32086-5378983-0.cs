    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace Test
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                Stopwatch sw = new Stopwatch();
    
                for (int i = 0; i < 10; ++i)
                {
                    sw.Reset();
                    sw.Start();
                    Thread.Sleep(50);
                    sw.Stop();
    
                    Console.WriteLine("(default) Slept for " + sw.ElapsedMilliseconds);
    
                    TimeBeginPeriod(1);
                    sw.Reset();
                    sw.Start();
                    Thread.Sleep(50);
                    sw.Stop();
                    TimeEndPeriod(1);
    
                    Console.WriteLine("(highres) Slept for " + sw.ElapsedMilliseconds + "\n");
                }
            }
    
            [DllImport("winmm.dll", EntryPoint="timeBeginPeriod", SetLastError=true)]
            private static extern uint TimeBeginPeriod(uint uMilliseconds);
    
            [DllImport("winmm.dll", EntryPoint="timeEndPeriod", SetLastError=true)]
            private static extern uint TimeEndPeriod(uint uMilliseconds);
        }
    }

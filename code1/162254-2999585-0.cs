    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            //timeBeginPeriod(1);
            var sw1 = Stopwatch.StartNew();
            for (int ix = 0; ix < 100; ++ix) Thread.Sleep(10);
            sw1.Stop();
            var sw2 = Stopwatch.StartNew();
            var mre = new ManualResetEvent(false);
            for (int ix = 0; ix < 100; ++ix) mre.WaitOne(10);
            sw1.Stop();
            Console.WriteLine("Sleep: {0}, Wait: {1}", sw1.ElapsedMilliseconds, sw2.ElapsedMilliseconds);
            Console.ReadLine();
            //timeEndPeriod(1);
        }
        [DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int period);
        [DllImport("winmm.dll")]
        private static extern int timeEndPeriod(int period);
    }

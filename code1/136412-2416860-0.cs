    using System;
    using System.Diagnostics;
    using System.Threading;
    static class Program {
        static void Main()
        {
            const int lockIterations = 50000000;
            object object1 = new object();
            lock (object1) { Console.WriteLine("First one has to pay an extra toll"); }
            Stopwatch csLock = Stopwatch.StartNew();
            for (int i = 0; i < lockIterations; ) {
                lock (object1) { i++; }
            }
            csLock.Stop();
            Console.WriteLine("lock: " + csLock.ElapsedMilliseconds + "ms");
            Stopwatch csMonitorTryEnter = Stopwatch.StartNew();
            for (int i = 0; i < lockIterations; ) {
                if (Monitor.TryEnter(object1, TimeSpan.FromSeconds(10))) {
                    try { i++; } finally { Monitor.Exit(object1); }
                }
            }
            csMonitorTryEnter.Stop();
            Console.WriteLine("Monitor.TryEnter: " + csMonitorTryEnter.ElapsedMilliseconds + "ms");
            csMonitorTryEnter = Stopwatch.StartNew();
            for (int i = 0; i < lockIterations; ) {
                if (Monitor.TryEnter(object1, 10000)) {
                    try { i++; } finally { Monitor.Exit(object1); }
                }
            }
            csMonitorTryEnter.Stop();
            Console.WriteLine("Monitor.TryEnter (2): " + csMonitorTryEnter.ElapsedMilliseconds + "ms");
            Stopwatch csMonitorEnter = Stopwatch.StartNew();
            for (int i = 0; i < lockIterations; ) {
                Monitor.Enter(object1);
                try { i++; } finally { Monitor.Exit(object1); }
            }
            csMonitorEnter.Stop();
            Console.WriteLine("Monitor.Enter: " + csMonitorEnter.ElapsedMilliseconds + "ms");
        }
    }

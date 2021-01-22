    using System;
    using System.Diagnostics;
    
    class Program
    {
        static void Main()
        {
            PerformanceCounterCategory pcg = new PerformanceCounterCategory("Network Interface");
            string instance = pcg.GetInstanceNames()[0];
            PerformanceCounter pcsent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instance);
            PerformanceCounter pcreceived = new PerformanceCounter("Network Interface", "Bytes Received/sec", instance);
            Console.WriteLine("Bytes Sent: {0}", pcsent.NextValue() / 1024);
            Console.WriteLine("Bytes Received: {0}", pcreceived.NextValue() / 1024);
        }
    }

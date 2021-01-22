    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    class Program
    {
    [DllImport("Kernel32", EntryPoint = "GetCurrentThreadId", ExactSpelling = true)]
    public static extern Int32 GetCurrentWin32ThreadId();
    static void Main(string[] args)
    {
        Dictionary<int, Thread> threads = new Dictionary<int, Thread>();
        // Launch the threads
        for (int i = 0; i < 5; i++)
        {
            Thread cpuThread = new Thread((start) =>
            {
                lock (threads)
                {
                    threads.Add(GetCurrentWin32ThreadId(), Thread.CurrentThread);
                }
                ConsumeCPU(20 * (int)start);
            });
            cpuThread.Name = "T" + i;
            cpuThread.Start(i);
        }
        // Every second wake up and see how much CPU each thread is using.
        Thread monitoringThread = new Thread(() =>
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.Write("\r");
                    double totalTime = ((double)watch.ElapsedMilliseconds);
                    if (totalTime > 0)
                    {
                        Process p = Process.GetCurrentProcess();
                        foreach (ProcessThread pt in p.Threads)
                        {
                            Thread managedThread;
                            if (threads.TryGetValue(pt.Id, out managedThread))
                            {
                                double percent = (pt.TotalProcessorTime.TotalMilliseconds / totalTime);
                                Console.Write("{0}-{1:0.00} ", managedThread.Name, percent);
                            }
                        }
                    }
                }
            });
        monitoringThread.Start();
    }
    // Helper function that generates a percentage of CPU usage
    public static void ConsumeCPU(int percentage)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        while (true)
        {
            if (watch.ElapsedMilliseconds > percentage)
            {
                Thread.Sleep(100 - percentage);
                watch.Reset();
                watch.Start();
            }
        }
    }
    }

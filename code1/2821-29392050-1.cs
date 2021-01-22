    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace Esquenta
    {
        class Program
        {
            private static int numThreads = 1;
            static bool affinity = false;
            static void Main(string[] args)
            {
                if (args.Contains("-a"))
                {
                    affinity = true;
                }
                if (args.Length < 1 || !int.TryParse(args[0], out numThreads))
                {
                    numThreads = 1;
                }
                Console.WriteLine("numThreads:" + numThreads);
                for (int j = 0; j < numThreads; j++)
                {
                    var param = new ParameterizedThreadStart(EsquentaP);
                    var thread = new Thread(param);
                    thread.Start(j);
                }
    
            }
    
            static void EsquentaP(object numero_obj)
            {
                int i = 0;
                DateTime ultimo = DateTime.Now;
                if(affinity)
                {
                    Thread.BeginThreadAffinity();
                    CurrentThread.ProcessorAffinity = new IntPtr(1);
                }
                try
                {
                    while (true)
                    {
                        i++;
                        if (i == int.MaxValue)
                        {
                            i = 0;
                            var lps = int.MaxValue / (DateTime.Now - ultimo).TotalSeconds / 1000000;
                            Console.WriteLine("Thread " + numero_obj + " " + lps.ToString("0.000") + " M loops/s");
                            ultimo = DateTime.Now;
                        }
                    }
                }
                finally
                {
                    Thread.EndThreadAffinity();
                }
            }
            [DllImport("kernel32.dll")]
            public static extern int GetCurrentThreadId();
    
            [DllImport("kernel32.dll")]
            public static extern int GetCurrentProcessorNumber();
            private static ProcessThread CurrentThread
            {
                get
                {
                    int id = GetCurrentThreadId();
                    return Process.GetCurrentProcess().Threads.Cast<ProcessThread>().Single(x => x.Id == id);
                }
            }
        }
    }

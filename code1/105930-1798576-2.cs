    using System;
    using System.ComponentModel;
    using System.Threading;
    
    namespace BackgroundWorkerTest
    {
        internal class Program
        {
            private static BackgroundWorker _privateWorker;
    
            private static void Main()
            {
                PrintThread("Main");
                _privateWorker = new BackgroundWorker();
                _privateWorker.DoWork += WorkerDoWork;
                _privateWorker.RunWorkerCompleted += WorkerRunWorkerCompleted;
                _privateWorker.Disposed += WorkerDisposed;
                _privateWorker.RunWorkerAsync();
                _privateWorker.Dispose();
                _privateWorker = null;
    
                using (var BW = new BackgroundWorker())
                {
                    BW.DoWork += delegate
                                     {
                                         Thread.Sleep(2000);
                                         PrintThread("Using Worker Working");
                                     };
                    BW.Disposed += delegate { PrintThread("Using Worker Disposed"); };
                    BW.RunWorkerCompleted += delegate { PrintThread("Using Worker Completed"); };
                    BW.RunWorkerAsync();
                }
    
                Console.ReadLine();
            }
    
            private static void WorkerDisposed(object sender, EventArgs e)
            {
                PrintThread("Private Worker Disposed");
            }
    
            private static void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                PrintThread("Private Worker Completed");
            }
    
            private static void WorkerDoWork(object sender, DoWorkEventArgs e)
            {
                Thread.Sleep(2000);
                PrintThread("Private Worker Working");
            }
    
            private static void PrintThread(string caller)
            {
                Console.WriteLine("{0} Thread: {1}", caller, Thread.CurrentThread.ManagedThreadId);
            }
        }
    }

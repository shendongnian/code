    using System;
    using System.Threading;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Text;
    
    namespace BGWorker
    {
        class Program
        {
            static bool done = false;
    
            static void Main(string[] args)
            {
                BackgroundWorker bg = new BackgroundWorker();
                bg.DoWork += new DoWorkEventHandler(bg_DoWork);
                bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
                bg.RunWorkerAsync();
    
                while (!done)
                {
                    Console.WriteLine("Waiting in Main, tid " + Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(100);
                }
            }
    
            static void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                Console.WriteLine("Completed, tid " + Thread.CurrentThread.ManagedThreadId);
                done = true;
            }
    
            static void bg_DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine("Work Line: " + i + ", tid " + Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(500);
                }
            }
        }
    }

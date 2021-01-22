        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Diagnostics;
    
    
    namespace ConsoleApplication
    {
        class Program
        {
            private static Info info = new Info();
            
            static void Main(string[] args)
            {
                Thread[] t1 = new Thread[5];
                for (int i = 0; i < 5; i++)
                {
                    t1[i] = new Thread(info.DoWork);
                }
    
                Thread[] t2 = new Thread[5];
                for (int i = 0; i < 5; i++)
                {
                    t2[i] = new Thread(info.Process);
                }
    
                for (int i = 0; i < 5; i++)
                {
                    t1[i].Start();
                    t2[i].Start();
                }
    
                Console.ReadKey();
            }
        }
    
        class Info
        {
            public object SynObject = new object();
    
            public void DoWork()
            {
                Debug.Print("DoWork Lock Reached: {0}", Thread.CurrentThread.ManagedThreadId);
                lock (this.SynObject)
                {
                    Debug.Print("Thread Lock Enter: {0}", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(5000);
                    Debug.Print("Thread Lock Exit: {0}", Thread.CurrentThread.ManagedThreadId);
                }
            }
    
            public void Process()
            {
                Debug.Print("Process Lock Reached: {0}", Thread.CurrentThread.ManagedThreadId);
                lock (this.SynObject)
                {
                    Debug.Print("Process Lock Enter: {0}", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(5000);
                    Debug.Print("Process Lock Exit: {0}", Thread.CurrentThread.ManagedThreadId);
                }
            }
        }
    }
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Diagnostics;
    
    
    namespace ConsoleApplication
    {
        class Program
        {
            private static Info info = new Info();
            
            static void Main(string[] args)
            {
                Thread[] t1 = new Thread[5];
                for (int i = 0; i < 5; i++)
                {
                    t1[i] = new Thread(info.DoWork);
                }
    
                Thread[] t2 = new Thread[5];
                for (int i = 0; i < 5; i++)
                {
                    t2[i] = new Thread(info.Process);
                }
    
                for (int i = 0; i < 5; i++)
                {
                    t1[i].Start();
                    t2[i].Start();
                }
    
                Console.ReadKey();
            }
        }
    
        class Info
        {
            public object SynObject = new object();
    
            public void DoWork()
            {
                Debug.Print("DoWork Lock Reached: {0}", Thread.CurrentThread.ManagedThreadId);
                lock (this.SynObject)
                {
                    Debug.Print("Thread Lock Enter: {0}", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(5000);
                    Debug.Print("Thread Lock Exit: {0}", Thread.CurrentThread.ManagedThreadId);
                }
            }
    
            public void Process()
            {
                Debug.Print("Process Lock Reached: {0}", Thread.CurrentThread.ManagedThreadId);
                lock (this.SynObject)
                {
                    Debug.Print("Process Lock Enter: {0}", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(5000);
                    Debug.Print("Process Lock Exit: {0}", Thread.CurrentThread.ManagedThreadId);
                }
            }
        }
    }

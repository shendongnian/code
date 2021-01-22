    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            private static List<MyWorker> _Workers;
            static void Main(string[] args)
            {
                _Workers = new List<MyWorker>();
                for (int i = 0; i < 5; i++)
                {
                    _Workers.Add(CreateDefaultWorker(i));
                }
                StartJobs(20000);
                Console.ReadKey();
            }
            private static void StartJobs(int runtime)
            {
                Random rand = new Random();
                DateTime startTime = DateTime.Now;
                while (DateTime.Now - startTime < TimeSpan.FromMilliseconds(runtime))
                {
                    var freeWorker = GetFreeWorker();
                    if (freeWorker != null)
                    {
                        freeWorker.Worker.RunWorkerAsync(new Action(() => DoSomething(freeWorker.Index, rand.Next(500, 2000))));
                    }
                    else
                    {
                        Console.WriteLine("No free worker available!");
                        Console.WriteLine("Waiting for free one...");
                        WaitForFreeOne();
                    }
                }
            }
            private static MyWorker GetFreeWorker()
            {
                foreach (var worker in _Workers)
                {
                    if (!worker.Worker.IsBusy)
                        return worker;
                }
                return null;
            }
            private static void WaitForFreeOne()
            {
                while (true)
                {
                    foreach (var worker in _Workers)
                    {
                        if (!worker.Worker.IsBusy)
                            return;
                    }
                    Thread.Sleep(1);
                }
            }
            private static MyWorker CreateDefaultWorker(int index)
            {
                var worker = new MyWorker(index);
                worker.Worker.DoWork += (sender, e) => ((Action)e.Argument).Invoke();
                worker.Worker.RunWorkerCompleted += (sender, e) => Console.WriteLine("Job finished in worker " + worker.Index);
                return worker;
            }
            static void DoSomething(int index, int timeout)
            {
                Console.WriteLine("Worker {1} starts to work for {0} ms", timeout, index);
                Thread.Sleep(timeout);
            }
        }
        public class MyWorker
        {
            public int Index { get; private set; }
            public BackgroundWorker Worker { get; private set; }
            public MyWorker(int index)
            {
                Index = index;
                Worker = new BackgroundWorker();
            }
        }
    }

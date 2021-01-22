    public class AutoResetEventSample
        {
            private AutoResetEvent autoReset = new AutoResetEvent(false);
            public void RunAll()
            {
                new Thread(Worker1).Start();
                new Thread(Worker2).Start();
                new Thread(Worker3).Start();
                autoReset.Set();
                Thread.Sleep(1000);
                autoReset.Set();
                Console.WriteLine("Main thread reached to end.");
            }
            public void Worker1()
            {
                Console.WriteLine("Entered in worker 1");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Worker1 is running {0}", i);
                    Thread.Sleep(2000);
                    autoReset.WaitOne();
                }
            }
            public void Worker2()
            {
                Console.WriteLine("Entered in worker 2");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Worker2 is running {0}", i);
                    Thread.Sleep(2000);
                    autoReset.WaitOne();
                }
            }
            public void Worker3()
            {
                Console.WriteLine("Entered in worker 3");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Worker3 is running {0}", i);
                    Thread.Sleep(2000);
                    autoReset.WaitOne();
                }
            }
        }

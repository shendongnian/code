    public class ManualResetEventSample
    {
        private ManualResetEvent manualReset = new ManualResetEvent(false);
        public void RunAll()
        {
            new Thread(Worker1).Start();
            new Thread(Worker2).Start();
            new Thread(Worker3).Start();
            manualReset.Set();
            Thread.Sleep(1000);
            manualReset.Reset();
            Console.WriteLine("Press to release all threads.");
            Console.ReadLine();
            manualReset.Set();
            Console.WriteLine("Main thread reached to end.");
        }
        public void Worker1()
        {
            Console.WriteLine("Entered in worker 1");
            for (int i = 0; i < 5; i++) {
                Console.WriteLine("Worker1 is running {0}", i);
                Thread.Sleep(2000);
                manualReset.WaitOne();
            }
        }
        public void Worker2()
        {
            Console.WriteLine("Entered in worker 2");
            for (int i = 0; i < 5; i++) {
                Console.WriteLine("Worker2 is running {0}", i);
                Thread.Sleep(2000);
                manualReset.WaitOne();
            }
        }
        public void Worker3()
        {
            Console.WriteLine("Entered in worker 3");
            for (int i = 0; i < 5; i++) {
                Console.WriteLine("Worker3 is running {0}", i);
                Thread.Sleep(2000);
                manualReset.WaitOne();
            }
        }
    }

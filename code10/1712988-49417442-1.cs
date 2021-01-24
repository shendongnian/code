    static void Main(string[] args)
        {
            var t = MainAsync(args);
            t.Wait();
            Console.ReadKey();
        }
        static async Task MainAsync(string[] args)
        {
            int availableThreadT1;
            int availableAsyncIOThreadT1;
            int availableThreadT2;
            int availableAsyncIOThreadT2;          
            ThreadPool.GetAvailableThreads(out availableThreadT1, out availableAsyncIOThreadT1);
            //var t1 = FakeAsync(); => Locked threads 2
            var t2 = RealAsync(); //Locked threads 0
            ThreadPool.GetAvailableThreads(out availableThreadT2, out availableAsyncIOThreadT2);
            //Console.Write($"Locked threads from FakeAsync {availableThreadT1 - availableThreadT2} \r\n");
            Console.Write($"Locked threads from RealAsync {availableThreadT1 - availableThreadT2} \r\n");
            
        }
        static async Task<int> FakeAsync()
        {
           var t = Task.Run(() => 
            {
                Thread.Sleep(1000);
            });
            await t;
            return 1;
        }
        static async Task<int> RealAsync()
        {
            var t = Task.Delay(1000);
            await t;
            return 1;
        }
    }

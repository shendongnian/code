        static ConcurrentDictionary<string, object> locks = new ConcurrentDictionary<string, object>();
        static void Main(string[] args)
        {
            locks.TryAdd("foo", new object());
            Task.Run(() => Worker1());
            Task.Run(() => Worker2());
            Console.ReadKey();
        } 
        static void Worker1()
        {
            object lockObj = null;
            locks.TryGetValue("foo", out lockObj);
            lock (lockObj)
            {
                Console.WriteLine("Worker1");
                Thread.Sleep(10000);
            }
        }
        static void Worker2()
        {
            object lockObj = null;
            locks.TryGetValue("foo", out lockObj);
            lock (lockObj)
            {
                Console.WriteLine("Worker2"); 
            }
        }

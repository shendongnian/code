    class Program
    {
        static object syncRoot = new object();
        static byte b;
        public static byte Function1()
        {
            lock (syncRoot)
            {
                // new thread starting in Function2;
                new Thread(Function2).Start();
                Monitor.Wait(syncRoot);
            }
            return b;
        }
        static public void Function2()
        {
            // do some thing
            b = 1;
            //We need to take the lock here as well
            lock (syncRoot)
            {
                Monitor.Pulse(syncRoot);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Function1());
        }
    }

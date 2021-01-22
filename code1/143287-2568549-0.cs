    class Program
    {
        static object syncRoot = new object();
        //lock implies a membar, no need for volatile here.
        static bool finished = false;
        static byte b;
        public static byte Function1()
        {
            lock (syncRoot)
            {
                //Wait only if F2 has not finished yet.
                if (!finished)
                {
                    Monitor.Wait(syncRoot);
                }
            }
            return b;
        }
        static public void Function2()
        {
            // do some thing
            b = 1;
            lock (syncRoot)
            {
                finished = true;
                Monitor.Pulse(syncRoot);
            }
        }
        static void Main(string[] args)
        {
            new Thread(Function2).Start();
            Console.WriteLine(Function1());
        }
    }

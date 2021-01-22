    class Program
    {
        static object syncRoot = new object();
        static int count = 10;
        static byte[] b = new byte[count];
        public static byte[] Function1()
        {
            lock (syncRoot)
            {
                //Wait for all threads to finish.
                while (count > 0)
                {
                    Monitor.Wait(syncRoot);
                }
            }
            return b;
        }
        static public void Function2()
        {
            // do some thing
            byte myresult = 1;
            lock (syncRoot)
            {
                //Access b and count at the end, from the lock
                b[--count] = myresult;
                Monitor.Pulse(syncRoot);
            }
        }
        static void Main(string[] args)
        {
            for (int i = count; i > 0; i--)
            {
                new Thread(Function2).Start();
            }
            byte[] result = Function1();
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }

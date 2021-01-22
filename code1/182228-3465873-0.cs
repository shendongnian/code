    class Program
    {
        static object locker = new object();
        static int count=0;
        static void Main(string[] args)
        {
            for (int j = 0; j < 100; j++)
            {
                (new Thread(new ParameterizedThreadStart(dostuff))).Start(j);
            }
            Console.ReadKey();
        }
        static void dostuff(object Id)
        {
            lock (locker)
            {
                count++;
                Console.WriteLine("Thread {0}: Count is {1}", Id, count);
            }
        }
    }

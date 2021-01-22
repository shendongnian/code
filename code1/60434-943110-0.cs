    class Program
    {
        private static Mutex mutex;
        static void Main(string[] args)
        {
            mutex = new Mutex(true, "MyMutex");
            if (!mutex.WaitOne(0, false))
            {
                return;
            }
            Console.WriteLine("Application started");
            Console.ReadKey(true);
        }
    }

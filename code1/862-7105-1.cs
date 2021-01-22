    public class Singleton
    {
        private static Singleton instance;
        // Added a static mutex for synchronising use of instance.
        private static System.Threading.Mutex mutex;
        private Singleton() { }
        static Singleton()
        {
            instance = new Singleton();
            mutex = new System.Threading.Mutex();
        }
        
        public static Singleton Acquire()
        {
            mutex.WaitOne();
            return instance;
        }
        
        // Each call to Acquire() requires a call to Release()
        public static void Release()
        {
            mutex.ReleaseMutex();
        }
    }

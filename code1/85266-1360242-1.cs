    public class Singleton
    {
        private Singleton() {}
        public void DoWork()
        { 
            // do something
        }
        // You can call this static method which calls the singleton instance method.
        public static void DoSomeWork()
        { 
            Instance.DoWork();
        }
        public static Singleton Instance
        {
            get { return instance; } 
        }
        private static Singleton instance = new Singleton();
    }

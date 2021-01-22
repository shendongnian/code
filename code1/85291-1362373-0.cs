    public class Singleton
    {
    
        private volatile static Singleton uniqueInstance;
        private static readonly object padlock = new object();
    
        private Singleton() { }
    
        public static Singleton getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton();
                    }
                }
            }
            return uniqueInstance;
        }
    }

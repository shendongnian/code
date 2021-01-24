    public sealed class Singleton
    {
        Singleton()
        {
        }
        private static readonly object padlock = new object();
        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }

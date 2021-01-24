    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();
        
        //add public properties here to use for your config!
        public Color ColCurrentPrimary { get; set; }
        Singleton()
        {
        }
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

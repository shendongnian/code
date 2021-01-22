    public sealed class Singleton
    {
        static readonly Singleton instance = new Singleton();
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
        static Singleton() { }
        private Singleton() { }
    }

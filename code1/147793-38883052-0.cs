    public sealed class Singleton
    {
        private static readonly Singleton _instance;
        private Singleton() { }
        static Singleton()
        {
            _instance = new Singleton();
        }
        public static Singleton Instance
        {
            get { return _instance; }
        }
    }

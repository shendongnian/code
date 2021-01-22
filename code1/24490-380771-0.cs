    public class Singleton
    {
        private Singleton() {}
        private static Singleton _instance = new Singleton();
        public static Singleton Instance { get { return _instance; }}
    }

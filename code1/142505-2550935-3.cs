    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        public static Singleton Instance { get { return instance; } }
        static Singleton() {}
        private Singleton() {}
    }

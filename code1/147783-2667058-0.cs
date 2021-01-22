    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private static Singleton() {} // Make sure it's truly lazy
        private Singleton() {} // Prevent instantiation outside
        
        public static Singleton Instance { get { return instance; }
    }

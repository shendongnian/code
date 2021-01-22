    public class Singleton
    {
        static public Singleton Instance { get; } = new Singleton();
        private Singleton() { ... }
    }

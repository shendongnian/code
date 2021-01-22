    public sealed class Singleton
    {
        private Singleton() { }
        public Singleton Instance { get; } = new Singleton();
    }

    public sealed class Singleton
    {
        private static readonly Singleton singleton= new Singleton();
        
        public static Singleton Instance { get { return singleton; } }
    
        private Singleton()
        {
        }
    }

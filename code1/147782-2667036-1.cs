    public sealed class Singleton
    {
        Singleton _instance = null;
    
        public Singleton Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Singleton();
                return _instance;
            }
        }
        // Default private constructor so only we can instanctiate
        private Singleton() { }
        // Default private static constructor
        private static Singleton() { }
    }

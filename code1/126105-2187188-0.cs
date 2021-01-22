    public sealed class Singleton
    {
        Singleton()
        {
        }
    
        public static Singleton Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        
        class Nested
        {
            static Nested()
            {
            }
    
            internal static readonly Singleton instance = new Singleton();
        }
    }

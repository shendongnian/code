    public sealed class Singleton
    {
        Singleton(){}
        public static Singleton Instance
        {
            get
            {
                return Nested.instance;
            }
        }        
        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {}    
            internal static readonly Singleton instance = new Singleton();
        }
    }

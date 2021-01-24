    Approach 1
    public sealed class Singleton {
        //Private ctor of course :P
        private Singleton() {}
        // Instance property to access Singleton Instance
        public static Singleton Instance { get { return Nested.instance; } }
        
        private class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() { }
            internal static readonly Singleton instance = new Singleton();
        }
    }
    Approach 2
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy =
            new Lazy<Singleton>(() => new Singleton());
    
        public static Singleton Instance { get { return lazy.Value; } }
        private Singleton()
        {
     }
    }

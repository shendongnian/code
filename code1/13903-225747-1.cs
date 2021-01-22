    public sealed class Singleton : IDisposable
    {
        Singleton()
        {
        }
    
        public static Singleton Instance
        {
            get
            {
                if (!Nested.released)
                    return Nested.instance;
                else
                    throw new ObjectDisposedException();
            }
        }
    
        public void Dispose()
        {
             disposed = true;
             // Do release stuff here
        }
    
        private bool disposed = false;
    
        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
    
            internal static readonly Singleton instance = new Singleton();
        }
    }

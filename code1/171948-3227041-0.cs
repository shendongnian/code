    public sealed class Singleton
    {
        static readonly Singleton instance=new Singleton();
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton()
        {
        }
    
        Singleton()
        {
        }
    
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }

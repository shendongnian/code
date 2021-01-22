    public sealed class Singleton
    {
        static class SingletonCreator
        {
            internal static readonly Singleton Instance = new Singleton();
        }
    
        public static Singleton Instance
        {
            get { return SingletonCreator.Instance; }
        }
    }

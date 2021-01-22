    public sealed class Singleton
    {
        static class SingletonCreator
        {
            // This may seem odd: read about this at: http://www.yoda.arachsys.com/csharp/beforefieldinit.html
            static SingletonCreator() {}
            internal static readonly Singleton Instance = new Singleton();
        }
    
        public static Singleton Instance
        {
            get { return SingletonCreator.Instance; }
        }
    }

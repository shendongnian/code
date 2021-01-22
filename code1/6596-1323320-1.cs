    public sealed class Singleton
    {
      private static readonly Singleton _instance = new Singleton();
    
      private Singleton()
      {
      }
    
      public static Singleton Instance
      {
        get
        {
          return _instance;
        }
      }
    }

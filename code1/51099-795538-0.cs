    public sealed class Singleton
    {
    static readonly Singleton _instance = new Singleton();
    
    // private ctor
    Singleton() {}
    
     public static Singleton Instance
     {
      get { return _instance; }
     }
    }

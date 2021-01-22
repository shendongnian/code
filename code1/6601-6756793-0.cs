    public sealed class Singleton
    { 
       private Singleton() { }
       public static Singleton Instance
       {
          get
          {
             return SingletonCreator.instance;
          }
       }
       
       private class SingletonCreator
       {
          static SingletonCreator() { }
          internal static readonly Singleton instance = new Singleton();
       }
    }

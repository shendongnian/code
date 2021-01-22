    public class Singleton<T> where T: Singleton<T>, new()
    {
      public static T Instance { get; private set; }
      static Singleton<T>()
      {
        Instance = new T();
      }
    }

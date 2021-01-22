    public class MySingleton
    {
      private MySingleton() {}
      public static readonly MySingleton Instance = new MySingleton();
    }

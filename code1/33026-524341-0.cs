    public class Meh<T>
      where T : new()
    {
      public static T CreateOne()
      {
        return new T();
      }
    }

    public class Base
    {
      public static T Copy<T>(T data) where T : Base
      {
        return data.MemberwiseClone() as T;
      }
    }

    public abstract class Derived : Base
    {
    
    }
    public static class Helper<T> where T : Base
    {
       public static string SomeProperty => GetMyProperty();
    
       public static string GetMyProperty()
       {
          if (typeof(T) == typeof(Derived))
          {
             return "asd";
          }
    
          throw new ArgumentOutOfRangeException();
       }
    }

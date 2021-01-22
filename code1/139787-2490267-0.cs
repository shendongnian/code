    class Program
    {
      static void Main(string[] args)
      {
        PrintDefault(typeof(object));
        PrintDefault(typeof(string));
        PrintDefault(typeof(int));
        PrintDefault(typeof(int?));
      }
    
      private static void PrintDefault(Type type)
      {
        Console.WriteLine("default({0}) = {1}", type,
          DefaultGenerator.GetDefaultValue(type));
      }
    }
    
    public class DefaultGenerator
    {
      public static object GetDefaultValue(Type parameter)
      {
        var defaultGeneratorType =
          typeof(DefaultGenerator<>).MakeGenericType(parameter);
    
        return defaultGeneratorType.InvokeMember(
          "GetDefault", 
          BindingFlags.Static |
          BindingFlags.Public |
          BindingFlags.InvokeMethod,
          null, null, new object[0]);
      }
    }
    
    public class DefaultGenerator<T>
    {
      public static T GetDefault()
      {
        return default(T);
      }
    }

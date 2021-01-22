    public static class Program
    {
      static void Main(string[] args)
      {
         Controller c1 = new Controller();
         Action a1 = c1.Method1;
         Console.WriteLine(a1.HasAttribute<Controller.TestAttribute>());
      }
      public static bool HasAttribute<T>(this Action method)
      {
         return method.Method.GetCustomAttributes(typeof(T), false).Any();
      }
    }
    class Controller
    {
      [AttributeUsage(AttributeTargets.Method)]
      public class TestAttribute : System.Attribute
      {
      }
      [Test()]
      public void Method1()
      {
      }
    }

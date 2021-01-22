    internal class Program
    {
      private static void Main(string[] args)
      {
        var staticMethodClasses = new List<StaticMethodClassBase> 
                                             {new ClassA(), new ClassB()};
        
        foreach (StaticMethodClassBase item in staticMethodClasses)
        {
          Type t = item.GetType();
          MethodInfo staticMethod = 
               t.GetMethod("DoSomething", BindingFlags.Static | BindingFlags.Public);
          staticMethod.Invoke(null, null);
        }
      }
    }
    public abstract class StaticMethodClassBase
    {
    }
    public class ClassA : StaticMethodClassBase
    {
        public new static void DoSomething()
        {
            Console.WriteLine("Class A");
        }
    }
    public class ClassB : StaticMethodClassBase
    {
        public new static void DoSomething()
        {
            Console.WriteLine("Class B");
        }
    }

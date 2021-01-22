    using System;
    using System.Reflection;
    
    namespace ConsoleApplication1 {
      class Program {
        static void Main(string[] args) {
          MyType<int> anInstance = new MyType<int>();
          Type type = anInstance.GetType();
          foreach (Type t in type.GetGenericArguments())
            Console.WriteLine(t.Name);
          Console.ReadLine();
        }
      }
      public class MyType<T> { }

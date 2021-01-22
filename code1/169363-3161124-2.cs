    using System;
    namespace ConsoleApplication2
    {
      class Program
      {
        static void Main(string[] args)
        {
          GenericClass<TypeX>.GenericMethod(new TypeX());
          GenericClass<TypeX>.GenericMethod(new TypeY());
          Console.ReadKey();
        }
      }
      public class TypeX {}
      public class TypeY : TypeX {}
      public static class GenericClass<T>
      {
        public static void GenericMethod(T target)
        {
          Console.WriteLine("TypeOf T: " + typeof(T).FullName);
          Console.WriteLine("Target Type: " + target.GetType().FullName);
          Console.WriteLine("T IsAssignable From Target Type: " + typeof(T).IsAssignableFrom(target.GetType()));
        }
      }
    }

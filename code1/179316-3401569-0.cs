    using System;
    namespace ConsoleApp {
       public class Bar {
       }
       public class Foo : Bar {
       }
       class Program {
          static void Main(string[] args) {
             var obj = new Foo();
             var isBoth = obj is Bar && obj is Foo;
             var isNotBoth = obj.GetType().Equals(typeof(Bar)) && obj.GetType().Equals(typeof(Foo));
             Console.Out.WriteLine("Using 'is': " + isBoth);
             Console.Out.WriteLine("Using 'GetType()': " + isNotBoth);
          }
       }
    }

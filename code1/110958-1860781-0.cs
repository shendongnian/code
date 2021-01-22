    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    
    namespace ConsoleApplication3
    {
      public abstract class Foo<T> where T : Foo<T>, new()
      {
        public static void StaticMethod()
        {
          T t = new T();
          t.VirtualMethod();
        }
    
        public abstract void VirtualMethod();
      }
    
      public class Bar : Foo<Bar>
      {
        public override void VirtualMethod()
        {
          System.Console.WriteLine("virtual from static!!!!");
        }
      }
      class Program
      {
        static void Main(string[] args)
        {
          Bar.StaticMethod();
        }
      }
    }

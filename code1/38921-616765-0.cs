    using System.Collections.Generic;
    using System;
    static class Program
    {
      static void Main()
      {
        Bar bar = new Bar();
        Baz baz = new Baz();
        System.Console.WriteLine(
                "We have {0} bars, rejoice!", bar.Cache.Count);
        System.Console.ReadKey();
      }
    }
    
    public abstract class Foo
    {
      public Foo()
      {
        Cache = new List<string>();
      }
      public List<String> Cache { get; set; }
    }
    
    public class Bar : Foo
    {
      public Bar() 
      { 
        Cache.Add("Bar"); 
      }
    }
    public class Baz : Foo
    {
      public Baz() { Cache.Add("Baz"); }
    }

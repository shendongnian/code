    using System;
    using System.Collections.Generic;
    static class Program
    {
        static void Main()
        {
            var bar = new Bar();
            var baz = new Baz();
            System.Console.WriteLine(
                    "We have {0} bars, rejoice!", Bar.Cache.Count);
    
            bar.PrintList();
            baz.PrintList();
        }
    }
    
    public abstract class Foo<T>
    {
        public static List<T> Cache = new List<T>();
    
        public void PrintList()
        {
            foreach(var item in Cache)
            {
                Console.WriteLine(item);
                    
            }
        }
    }
    
    public class Bar : Foo<Bar>
    {
        public Bar() { Cache.Add(this); }
    }
    public class Baz : Foo<Baz>
    {
        public Baz() { Cache.Add(this); }
    }

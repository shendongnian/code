    using System.Collections.Generic;
    static class Program
    {
        static void Main()
        {
            bar Bar = new bar();
            baz Baz = new baz();
            System.Console.WriteLine(
                    "We have {0} bars, rejoice!", bar.Cache.Count);
        }
    }
    
    public abstract class foo<T>
    {
        public static List<foo<T> > Cache = new List<foo<T> >();
    }
    
    public class bar : foo<bar>
    {
        public bar() { Cache.Add(this); }
    }
    public class baz : foo<baz>
    {
        public baz() { Cache.Add(this); }
    }

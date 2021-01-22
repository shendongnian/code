    using System.Collections;
    using System.Collections.Generic;
    
    static class Program
    {
        static void Main()
        {
            bar Bar = new bar();
            baz Baz = new baz();
            System.Console.WriteLine(
                    "We have {0} bars, rejoice!", Bar.GetCache().Count);
        }
    }
    
    public abstract class foo<T>
    {
        private static List<foo<T> > Cache = new List<foo<T> >();
    
        public IList GetCache()
        {
            return Cache;
        }
    }
    
    public class bar : foo<bar>
    {
        public bar() { GetCache().Add(this); }
    }
    public class baz : foo<baz>
    {
        public baz() { GetCache().Add(this); }
    }

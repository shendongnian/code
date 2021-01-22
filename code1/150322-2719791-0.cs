    using System;
    using System.Linq.Expressions;
    
    public class Foo
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            Expression<Func<int, Foo>> builder = 
                z => new Foo { X = z, Y = z };
        }
    }

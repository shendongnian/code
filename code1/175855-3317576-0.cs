    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    class T { }
    class X : T { }
    class Y : T { }
    
    class Program
    {
        static void Main()
        {
            IEnumerable<X> xs = new List<X>();
            IEnumerable<Y> ys = new List<Y>();
            IEnumerable<T> result = xs.Concat<T>(ys);
        }
    }

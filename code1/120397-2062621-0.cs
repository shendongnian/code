    using System;
    using System.Collections.Generic;
    using System.Linq;
    static class Program
    {
        static void Main()
        {
            Func<long, long, long, IEnumerable<long>> fib = null;
            fib = (n, m, cap) => n + m > cap ? Enumerable.Empty<long>()
                : Enumerable.Repeat(n + m, 1).Concat(fib(m, n + m, cap));
    
            var list = fib(0, 1, 1000).ToList();
        }
    }

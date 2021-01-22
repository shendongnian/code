    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    static class Program {
        static IEnumerable<long> Fibonacci() {
            long n = 0, m = 1;
    
            yield return 0;
            yield return 1;
            while (true) {
                long tmp = n + m;
                n = m;
                m = tmp;
                yield return m;
            }
        }
        static void Main() {
            foreach (long i in Fibonacci().Take(10)) {
                Console.WriteLine(i);
            }
        }
    }

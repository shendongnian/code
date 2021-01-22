            // Sequential prime number generator
            var primes_ = from n in range
                         let w = (int)Math.Sqrt(n)
                         where Enumerable.Range(2, w).All((i) => n % i > 0)
                         select n;
            // Note sequence of output:
            // 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 
            foreach (var p in primes_)
                Trace.Write(p + ", ");
            Trace.WriteLine("");

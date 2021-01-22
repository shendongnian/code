    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static IEnumerable<T> InitInfinite<T>(Func<T> f)
        {
            while (true)
            {
                yield return f();
            }
        }
        static int N = 5;
        static int GetNumber()
        {
            N--;
            return N;
        }
        static bool NotZero(int n) { return n != 0; }
        static void Main(string[] args)
        {
            foreach (var x in InitInfinite(() => GetNumber()).TakeWhile(NotZero))
            {
                Console.WriteLine(1.0/x);
            }
        }
    }

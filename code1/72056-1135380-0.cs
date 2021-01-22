    using System;
    
    class Program {
        static void Main(string[] args) {
            var i1 = test(10);
            var i2 = test(20);
            System.Console.WriteLine(object.ReferenceEquals(i1, i2));
        }
    
        static Func<int, int> test(int x) {
            Func<int, int> inc = y => y + 1;
            Console.WriteLine(inc(x));
            return inc;
        }
    }

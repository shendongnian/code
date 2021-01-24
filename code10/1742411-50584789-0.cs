    using System;
    using System.Collections.Generic;
    using MoreLinq;
    namespace Demo
    {
        class Test
        {
            public Test(int a, int b)
            {
                A = a;
                B = b;
            }
            public readonly int A;
            public readonly int B;
            public override string ToString()
            {
                return $"A={A}, B={B}";
            }
        }
        class Program
        {
            static void Main()
            {
                var list = new List<Test>
                {
                    new Test(1, 2),
                    new Test(2, 3),
                    new Test(3, 1),
                    new Test(3, 2),
                    new Test(2, 4),
                    new Test(4, 3)
                };
                var result = list.DistinctBy(x => (x.A > x.B) ? (x.A, x.B) : (x.B, x.A));
                foreach (var item in result)
                    Console.WriteLine(item);
            }
        }
    }

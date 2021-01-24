    using System;
    public struct S1
    {
        public int A;
        public void ChangeA(int a) => A = a;
    }
    public static class Program
    {
        static void Main()
        {
            var s1 = new S1 { A = 1 };
            S1Foo(in s1);
            Console.WriteLine(s1.A);
        }
        private static void S1Foo(in S1 s) => s.ChangeA(2);
    }

    using System;
    public readonly struct S2
    {
        private readonly int _a;
        public int A => _a;
        public S2(int a) => _a = a;
        public void ChangeA(int a) { }
    }
    public static class Program
    {
        static void Main()
        {
            var s2 = new S2(1);
            S2Foo(in s2);
            Console.WriteLine(s2.A);
        }
        private static void S2Foo(in S2 s) => s.ChangeA(2);
    }

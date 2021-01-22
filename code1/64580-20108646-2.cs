    using System;
    using System.Diagnostics;
    struct A
    {
        public int X;
        public int Y;
    }
    struct B : IEquatable<B>
    {
        public bool Equals(B other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
        public override bool Equals(object obj)
        {
            return obj is B && Equals((B)obj);
        }
        public int X;
        public int Y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var N = 100000000;
            A a = new A();
            a.X = 73;
            a.Y = 42;
            A aa = new A();
            a.X = 173;
            a.Y = 142;
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < N; i++)
            {
                if (a.Equals(aa))
                {
                    Console.WriteLine("never ever");
                }
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            B b = new B();
            b.X = 73;
            b.Y = 42;
            B bb = new B();
            b.X = 173;
            b.Y = 142;
            sw = Stopwatch.StartNew();
            for (int i = 0; i < N; i++)
            {
                if (b.Equals(bb))
                {
                    Console.WriteLine("never ever");
                }
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }

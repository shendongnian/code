    struct Foo : IEquatable<Foo>
    {
        public int a, b;
        public Foo(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public override bool Equals(object obj)
        {
    #if BOXING
            var obj_ = obj as Foo?;
            return obj_ != null && Equals(obj_.Value);
    #elif DOUBLECHECK
            return obj is Foo && Equals((Foo)obj);
    #elif MAGIC
            ?
    #endif
        }
        public bool Equals(Foo other)
        {
            return a == other.a && b == other.b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RunBenchmark(new Foo(42, 43), new Foo(42, 43));
            RunBenchmark(new Foo(42, 43), new Foo(43, 44));
        }
        static void RunBenchmark(Foo x, Foo y)
        {
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < 1000000000; i++) x.Equals(y);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }

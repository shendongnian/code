    class Foo
    {
        public string foo;
        public Foo(string foo) { this.foo = foo; }
    }
    class Bar
    {
        public int bar;
        public Bar(int bar) { this.bar = bar; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new List<dynamic>();
            test.Add(new Foo("Foo!"));
            test.Add(new Bar(42));
            Console.WriteLine(test[0].foo.Substring(0,3));
            Console.WriteLine(test[1].bar.ToString("000"));
            Console.ReadKey(true);
        }
    }

    public class Foo
    {
        public int A { get; set; }
        public int B { get; set; }
    }
    public class Loop
    {
        public int A { get; set; }
        public Loop B { get; set; }
    }
    public class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StaticPropertyTypeRecursiveEquality<string>.Equals(
                "foo", "bar"));
            Console.WriteLine(StaticPropertyTypeRecursiveEquality<Foo>.Equals(
                new Foo() { A = 1, B = 2  },
                new Foo() { A = 1, B = 2 }));
            Console.WriteLine(StaticPropertyTypeRecursiveEquality<Loop>.Equals(
                new Loop() { A = 1, B = new Loop() { A = 3 } },
                new Loop() { A = 1, B = new Loop() { A = 3 } }));
            Console.ReadLine();
        }
    }

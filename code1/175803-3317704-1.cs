        class A
        {
            public String Foo { get; set; }
            public Int32 Bar { get; set; }
            public override string ToString()
            {
                return Foo + ":" + Bar.ToString();
            }
        }
        static void Main(string[] args)
        {
            var x = new List<A> { new A { Foo = "ABC", Bar = 100 }, new A() { Foo = "ZZZ", Bar = 0 } };
            Func<A, String> order1 = (a) => a.Foo;
            Func<A, Int32> order2 = (a) => a.Bar;
            PrintQuery(x, order1);
            Console.WriteLine();
            PrintQuery(x, order2);
            Console.ReadLine();
        }
        static void PrintQuery<T>(IEnumerable<A> query, Func<A, T> orderFunc)
        {
            foreach (var e in query.OrderBy(orderFunc))
                Console.WriteLine(e);
        }

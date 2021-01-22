        class A
        {
            public String Foo { get; set; }
            public Int32 Bar { get; set; }
        }
        static void Main(string[] args)
        {
            var x = new List<A> { new A { Foo = "ABC", Bar = 100 }, new A() { Foo = "ZZZ", Bar = 0 } };
            Func<A, Object> order1 = (a) => a.Foo;
            Func<A, Object> order2 = (a) => a.Bar;
            PrintQuery(x, order1);
            PrintQuery(x, order2);
            
            Console.ReadLine();
        }
        static void PrintQuery(IEnumerable<A> query, Func<A, Object> orderFunc)
        {
            foreach (var e in query.OrderBy(orderFunc))
                Console.WriteLine(e);
        }

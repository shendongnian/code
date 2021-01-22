        class Foo
        {
            public string Bar { get; set; }
            public static List<Foo> FooMeUp()
            {
                var foos = new List<Foo>();
                for (int i = 0; i < 10000000; i++)
                {
                    foos.Add(new Foo() { Bar = (i % 2 == 0) ? "something" : i.ToString() });
                }
                return foos;
            }
        }
        static void Main(string[] args)
        {
            var foos = Foo.FooMeUp();
            Stopwatch sw = Stopwatch.StartNew();
            List<string> strings = new List<string>();
            foreach (Foo o in foos)
            {
                if (o.Bar == "something")
                {
                    strings.Add(o.Bar);
                }
            }
            sw.Stop();
            Console.WriteLine("It took {0}", sw.ElapsedMilliseconds);
            sw = Stopwatch.StartNew();
            strings = new List<string>();
            foreach (Foo o in foos)
            {
                var s = o.Bar;
                if (s == "something")
                {
                    strings.Add(s);
                }
            }
            sw.Stop();
            Console.WriteLine("It took {0}", sw.ElapsedMilliseconds);
            Console.ReadLine();
        }

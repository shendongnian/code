    class Program
    {
        static void Main(string[] args)
        {
            string delimeter = ",";
            List<Foo> items = new List<Foo>() { new Foo { Boo = "ABC" }, new Foo { Boo = "DEF" },
                new Foo { Boo = "GHI" }, new Foo { Boo = "JKL" } };
            Console.WriteLine(items.Aggregate((i, j) => new Foo{Boo = (i.Boo + delimeter + j.Boo)}).Boo);
            Console.ReadKey();
        }
    }

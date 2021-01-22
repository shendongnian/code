    class Program
    {
        static void Main(string[] args)
        {
            // creates some foos
            List<Foo> fooList = new List<Foo>();
            fooList.Add(new Foo { Id = 1, BarId = 11 });
            fooList.Add(new Foo { Id = 2, BarId = 12 });
            fooList.Add(new Foo { Id = 3, BarId = 13 });
            fooList.Add(new Foo { Id = 4, BarId = 14 });
            fooList.Add(new Foo { Id = 5, BarId = -1 });
            fooList.Add(new Foo { Id = 6, BarId = -1 });
            fooList.Add(new Foo { Id = 7, BarId = -1 });
            // create some bars
            List<Bar> barList = new List<Bar>();
            barList.Add(new Bar { Id = 11 });
            barList.Add(new Bar { Id = 12 });
            barList.Add(new Bar { Id = 13 });
            barList.Add(new Bar { Id = 14 });
            barList.Add(new Bar { Id = 15 });
            barList.Add(new Bar { Id = 16 });
            barList.Add(new Bar { Id = 17 });
            var linked = from foo in fooList
                         from bar in barList
                         where foo.BarId == bar.Id
                         select foo;
            var notLinked = fooList.Except(linked);
            foreach (Foo item in notLinked)
            {
                Console.WriteLine(
                    String.Format(
                    "Foo.Id: {0} | Bar.Id: {1}", 
                    item.Id, item.BarId));
            }
            Console.WriteLine("Any key to continue...");
            Console.ReadKey();
        }
    }
    class Foo
    {
        public int Id { get; set; }
        public int BarId { get; set; }
    }
    class Bar
    {
        public int Id { get; set; }
    }

    namespace DoctaJonez.StackOverflow
    {
        class Program
        {
            static List<Bar> bars = new List<Bar>()
            {
                new Bar()
                {
                    Name = "Bar1",
                    TheFoo = new List<Foo>()
                    {
                        new Foo() { Name = "Foo1", Value = 1 },
                        new Foo() { Name = "Foo2", Value = 2 },
                        new Foo() { Name = "Foo3", Value = 3 }
                    }
                },
                new Bar()
                {
                    Name = "Bar2",
                    TheFoo = new List<Foo>()
                    {
                        new Foo() { Name = "Foo1", Value = 1 },
                        new Foo() { Name = "Foo2", Value = 2 }
                    }
                },
                new Bar()
                {
                    Name = "Bar2",
                    TheFoo = new List<Foo>()
                    {
                        new Foo() { Name = "Foo1", Value = 1 },
                        new Foo() { Name = "Foo5", Value = 5 }
                    }
                }
            };
    
            static void Main(string[] args)
            {
                var foobars = bars.ToDictionary(bar => bar, bar => bar.TheFoo.OrderByDescending(foo => foo.Value).FirstOrDefault());
    
                foreach (var keyValPair in foobars)
                {
                    Console.WriteLine("Bar name: {0}", keyValPair.Key.Name);
                    Console.WriteLine("Foo name: {0}, Foo value: {1}", keyValPair.Value.Name, keyValPair.Value.Value);
                }
            }
        }
    
        public class Foo
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    
        public class Bar
        {
            public string Name { get; set; }
            public IEnumerable<Foo> TheFoo { get; set; }
        }
    }

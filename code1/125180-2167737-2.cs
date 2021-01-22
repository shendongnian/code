    public class MyClass
    {
        class Foo
        {
            public int X, Y;
        }
        static IEnumerable<int> Flatten(IEnumerable<Foo> foos)
        {
            foreach (var foo in foos)
            {
                yield return foo.X;
                yield return foo.Y;
            }
        }
        public static void RunSnippet()
        {
            var foos = new List<Foo>()
            {
                new Foo() { X = 1, Y = 2 },
                new Foo() { X = 2, Y = 4 },
                new Foo() { X = 3, Y = 6 },
            };
            var query = Flatten(foos);
            foreach (var x in query)
            {
                Console.WriteLine(x);
            }
        }
    }

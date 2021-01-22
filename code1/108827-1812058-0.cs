    class Program
    {
        class Foo
        {
            public int FirstMemberValue { get; set; }
        }
        static void Main(string[] args)
        {
            var foos = new[] 
            { 
                new Foo { FirstMemberValue = 1 }, 
                new Foo { FirstMemberValue = 3 }, 
                new Foo { FirstMemberValue = 2 } 
            };
            Array.Sort(foos, (f1, f2) => f1.FirstMemberValue.CompareTo(f2.FirstMemberValue));
            foreach (var item in foos)
            {
                Console.WriteLine(item.FirstMemberValue);
            }
        }
    }

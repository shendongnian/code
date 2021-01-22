    public class Foo : IEquatable<Foo>
    {
        public string Bar { get; set; }
        public bool Equals(Foo other)
        {
            return string.Equals(other.Bar, Bar);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var foos = new List<Foo>(new[] 
            { 
                new Foo { Bar = "b1" },
                new Foo { Bar = "b2" },
                new Foo { Bar = "b3" },
            });
            var foo = new Foo { Bar = "b2" };
            Console.WriteLine(foos.IndexOf(foo)); // prints 1
        }
    }

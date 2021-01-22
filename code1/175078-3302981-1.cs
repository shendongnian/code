    struct Foo
    {
        public int X;
        public Bar B;
    }
    
    struct Bar
    {
        public int Y;
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            Foo foo;
            foo.X = 1;
            foo.B.Y = 2;
    
            // Show that both values are copied.
            Foo foo2 = foo;
            Console.WriteLine(foo2.X);     // Prints 1
            Console.WriteLine(foo2.B.Y);   // Prints 2
    
            // Show that modifying the copy doesn't change the original.
            foo2.B.Y = 3;
            Console.WriteLine(foo.B.Y);    // Prints 2
            Console.WriteLine(foo2.B.Y);   // Prints 3
        }
    }

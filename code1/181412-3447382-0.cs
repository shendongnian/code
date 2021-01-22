    static class Extensions
    {
        public static void Foo(this string x)
        {
            Console.WriteLine("Calling Foo on " + x);
        }
    }
    class Test
    {
        static void Main()
        {
            Action action = "text".Foo;
            Console.WriteLine(action.Target); // Prints "text"
        }
    }

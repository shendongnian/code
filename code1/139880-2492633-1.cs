    public static class OverloadTest
    {
        public static void Foo(int x)
        {
            Console.WriteLine("Foo(int)");
        }
        public static void Foo(bool x)
        {
            Console.WriteLine("Foo(bool)");
        }
        public static void Foo(object x)
        {
            Console.WriteLine("Foo(object)");
        }
    }

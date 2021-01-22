    class Foo
    {
        public static void Do() { Console.WriteLine("Foo.Do"); }
    }
    class Bar : Foo // :Foo added
    {
        public static void Something()
        {
            Do();
        }
    }

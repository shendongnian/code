    class Info<T>
    {
        public static string X;
    }
    Info<A1>.X = "Hello";
    Info<A2>.X = "World";
    Console.WriteLine(Info<A1>.X);  // prints "Hello"
    Console.WriteLine(Info<A2>.X);  // prints "World"

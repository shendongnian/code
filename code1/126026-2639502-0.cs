    using System;
    class A
    {
        static void Foo(string x, Action<Action> y) { Console.WriteLine(1); }
        static void Foo(object x, Func<Func<int>, int> y) { Console.WriteLine(2); }
        static void Main()
        {
            Foo(null, x => x()); // Prints 1
            Foo(null, x => (x())); // Prints 2
        }
    }

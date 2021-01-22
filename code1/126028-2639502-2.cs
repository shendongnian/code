    using System;
    class Program
    {
        static void Main()
        {
            Bar(x => (x).Foo(), ""); // Prints 1
            Bar(x => ((x).Foo)(), ""); // Prints 2
        }
        static void Bar(Action<C<int>> x, string y) { Console.WriteLine(1); }
        static void Bar(Action<C<Action>> x, object y) { Console.WriteLine(2); }
    }
    static class B
    {
        public static void Foo(this object x) { }
    }
    class C<T>
    {
        public T Foo;
    }

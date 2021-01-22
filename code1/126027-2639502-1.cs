    using System;
    class A
    {
        public A Select(Func<A, A> f)
        {
            Console.WriteLine(1);
            return new A();
        }
        public A Where(Func<A, bool> f)
        {
            return new A();
        }
        static void Main()
        {
            object x;
            x = from y in new A() where true select (y); // Prints 1
            x = from y in new A() where true select y; // Prints nothing
        }
    }

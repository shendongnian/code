    using System;
    public struct Foo
    {
        // Readonly, so must be immutable, right?
        public readonly string x;
        public Foo(string x)
        {
            this.x = x;
        }
        public void EvilEvilEvil()
        {
            this = new Foo();
        }
    }
    public class Test
    {
        static void Main()
        {
            Foo foo = new Foo("Test");
            Console.WriteLine(foo.x); // Prints "Test"
            foo.EvilEvilEvil();
            Console.WriteLine(foo.x); // Prints nothing
        }
    }

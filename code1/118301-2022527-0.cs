    using System;
    
    public struct Foo
    {
        // These change the calling code's correctness
        public static bool operator ==(Foo f1, Foo f2) { return false; }
        public static bool operator !=(Foo f1, Foo f2) { return false; }
        // These aren't relevant, but the compiler will issue an
        // unrelated warning if they're missing
        public override bool Equals(object x) { return false; }
        public override int GetHashCode() { return 0; }
    }
    
    public class Test
    {
        static void Main()
        {
            Foo f = new Foo();
            Console.WriteLine(f == null);
        }
    }

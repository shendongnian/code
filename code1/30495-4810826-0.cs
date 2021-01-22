    interface IA { }
    interface IB { }
    class CA1 : IA {}
    class CA2 : IA {}
    class CA11 : CA1 {}
    class CB1 : IB {}
    class CB2 : IB {}
    class MD
    {
        public enum X { X } ;
        public static void Foo(IA a, IB b, X dispatch = X.X) { Foo((dynamic)a, (dynamic)b); }
        static void Foo(IA a, IB b) { Console.WriteLine("IA IB"); }
        static void Foo(CA1 a, CB1 b) { Console.WriteLine("CA1 CB1"); }
        static void Foo(CA2 a, CB1 b) { Console.WriteLine("CA2 CB1"); }
        static void Foo(CA1 a, CB2 b) { Console.WriteLine("CA1 CB2"); }
        static void Foo(CA2 a, CB2 b) { Console.WriteLine("CA2 CB2"); }
        static void Foo(CA11 a, CB2 b) { Console.WriteLine("CA11 CB2"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = new CA1();
            var a11 = new CA11();
            var a2 = new CA2();
            var b1 = new CB1();
            var b2 = new CB2();
            MD.Foo(a1, b1);
            MD.Foo(a2, b1);
            MD.Foo(a1, b2);
            MD.Foo(a2, b2);
            MD.Foo(a11, b1);
            MD.Foo(a11, b2);
        }
    }

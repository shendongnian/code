    readonly struct S
    {
        public readonly int I;
        public S(int i) { this.I = i; }
    }
    class Program
    {
        static S s1 = new S(1);
        static void Main()
        {
            A(s1);
        }
        static void A(in S s2)
        {
            Console.Write(s2.I);
            s1 = new S(2); // This is legal even though S is readonly!
            Console.Write(s2.I);
        }
    }

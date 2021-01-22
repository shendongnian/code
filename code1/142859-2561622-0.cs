    class A { public int VarA; }
    class X
    {
        static void Main(string[] args)
        {
            A a1 = new A();
            a1.VarA = 5;
            A a2 = a1;
            a2.VarA = 10;
        }
    }

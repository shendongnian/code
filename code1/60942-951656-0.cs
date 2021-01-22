    class A
    {
        void Method(int a) {}
        static void Method2(int a) {}
        static void Main(string[] args)
        {
            PossiblyExecuteDelegate(A.Method2);
            A a = new A();
            PossiblyExecuteDelegate(a.Method);
        }
    }

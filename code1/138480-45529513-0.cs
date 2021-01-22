    interface IA
    {
        void PrintIA();
    }
    class  A:IA
    {
        public void PrintIA()
        {
            Console.WriteLine("PrintA method in Base Class A");
        }
    }
    interface IB
    {
        void PrintIB();
    }
    class B : IB
    {
        public void PrintIB()
        {
            Console.WriteLine("PrintB method in Base Class B");
        }
    }
    public class AB: IA, IB
    {
        A a = new A();
        B b = new B();
        public void PrintIA()
        {
           a.PrintIA();
        }
        public void PrintIB()
        {
            b.PrintIB();
        }
    }

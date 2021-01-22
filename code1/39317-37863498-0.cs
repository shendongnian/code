    public class A
    {
        B b;
        public A(B b) { this.b = b; }
        ~A()
        {
            b = new B();
        }
    }
    public class B
    {
        A a;
        public B() { this.a = new A(this); }
        ~B()
        {
            a = new A(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            {
                B[] toBeLost = new B[100000000];
                foreach (var c in toBeLost)
                {
                    toBeLost.ToString(); //to make JIT compiler run the instantiation above
                }
            }
            Console.ReadLine();
        }
    }

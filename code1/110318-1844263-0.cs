        class Program
    {
        static void Main(string[] args)
        {
            C c = new C();
            A a = new A();
            a.DoThis();
            Console.ReadKey();
        }
    }
    public class C
    {
        public virtual void DoThis() {
            Console.WriteLine("In C"); }
    }
    public class B : C
    {
        public new void DoThis()
        {
            Console.WriteLine("In B");
        }
    }
    public class A : B
    {
        public new void DoThis()
        {
            Console.WriteLine("In A..");
            ((C) this).DoThis();
        }
    }

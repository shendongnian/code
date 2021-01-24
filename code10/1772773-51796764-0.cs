    class Program
        {
            static void Main(string[] args)
            {
                A a = new B();
            }
        }
    public class A
    {
        
        public A()
        {
            DoIt();
        }
        public virtual void DoIt()
        {
            Console.WriteLine("A");
        }
    }
    public class B:A
    {
        
        public B()
        {
            
        }
        public override void DoIt()
        {
            Console.WriteLine("B");
        }
    }

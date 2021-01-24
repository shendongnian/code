    public class A
    {
        public B Child;
    }
    public class B
    {
        public A Parent;
    }
    public class Program
    {
        private static void Main()
        {
            A a = new A();
            B b = new B();
            a.Child = b;
            b.Parent = a;
    
            string json = JsonConvert.SerializeObject(a);
        }
    }

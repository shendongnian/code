    class A
    {
        public virtual string ReturnString()
        {
           return "ClassA::Method";
        }
    }
    class B : A
    {
        public override string ReturnString()
        {
            return "ClassB::Method";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.Read();
        }
    }

class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            A c = new B();
            // Straight A
            a.MyVirtualMethod();
            a.MyNonVirtualMethod();
            // Straight B
            b.MyVirtualMethod();
            b.MyNonVirtualMethod();
            // Polymorphic
            c.MyVirtualMethod();
            c.MyNonVirtualMethod();
            Console.ReadLine();
        }
    }
    public class A
    {
        public virtual void MyVirtualMethod()
        {
            Console.WriteLine("Hello world!");
        }
        public void MyNonVirtualMethod()
        {
            Console.WriteLine("Hello world!");
        }
    }
    public class B : A
    {
        public override void MyVirtualMethod()
        {
            Console.WriteLine("Good bye universe!");
        }
        public new void MyNonVirtualMethod()
        {
            Console.WriteLine("Good bye universe!");
        }
    }</code></pre>
The output of this code is not obvious to somebody that doesn't understand the implementation.
Hello world!
Hello world!
Good bye universe!
Good bye universe!
Good bye universe!
Hello world!

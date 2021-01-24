    static void Main()
    {
        var c = new C();
        c.Some();
        Console.ReadKey();
    }
    public class A
    {
        public virtual void Method()
        {
            Console.Write("A");
        }
    }
    public class B : A
    {
        public new void Method()
        {
            Console.Write("B");
        }
    }
    public class C : B
    {
        public void Some()
        {
            //How to call Method() from class A?
            ((A)this).Method();
        }
    }

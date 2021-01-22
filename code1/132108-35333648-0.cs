    public class A
    {
        public int i = 0;
        internal virtual void test()
        {
            Console.WriteLine("A test");
        }
    }
    public class B : A
    {
        public new int i = 1;
        public new void test()
        {
            Console.WriteLine("B test");
        }
    }
    public class C : B
    {
        public new int i = 2;
        public new void test()
        {
            Console.WriteLine("C test - ");
            (this as A).test(); 
        }
    }

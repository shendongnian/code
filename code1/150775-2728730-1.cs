    class Program
    {
        static void Main(string[] args)
        {
            A a1 = new A(1);
            B b1 = a1;
            B b2 = new B(1.1);
            A a2 = (A)b2;
        }
    }
    class A
    {
        public int Foo;
        public A(int foo)
        {
            this.Foo = foo;
        }
        public static implicit operator B(A a)
        {
            return new B(a.Foo);
        }
    }
    class B
    {
        public double Bar;
        public B(double bar)
        {
            this.Bar = bar;
        }
        public static explicit operator A(B b)
        {
            return new A((int)b.Bar);
        }
    }

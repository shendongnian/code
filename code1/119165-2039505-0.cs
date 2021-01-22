    class A
    {
        public void Foo()
        {
            Console.WriteLine("Foo called from A");
        }
        public virtual void Bar()
        {
            Console.WriteLine("Bar called from A");
        }
        public virtual void Baz()
        {
            Console.WriteLine("Baz called from A");
        }
    }
    class B : A
    {
        public new void Foo()
        {
            Console.WriteLine("Foo called from B");
        }
        public override void Bar()
        {
            Console.WriteLine("Bar called from B");
        }
        public override void Baz()
        {
            base.Baz();
            Console.WriteLine("Baz called from B");
        }
    }
    static void Main()
    {
        A a = new A();
        a.Foo();
        a.Bar();
        a.Baz();
        B b = new B();
        b.Foo();
        b.Bar();
        b.Baz();
        A a2 = new B();
        a2.Foo();
        a2.Bar();
        a2.Baz();
    }

    class A
    {
        public virtual void Foo() { Console.WriteLine("A::Foo()"); }
    }
    
    class B : A
    {
        public override void Foo() { Console.WriteLine("B::Foo()"); }
    }

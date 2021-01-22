    class A
    {
        public virtual void Foo() { Console.WriteLine("A::Foo()"); }
    }
    
    class B : A
    {
        public new void Foo() { Console.WriteLine("B::Foo()"); }
    }

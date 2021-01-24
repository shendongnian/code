    class A
        {
            public virtual void Process() { }
        }
        class B : A
        {
            public override void Process() { Console.WriteLine($"Inside: {nameof(B)}"); }
        }
        class C : A
        {
            public override void Process() { Console.WriteLine($"Inside: {nameof(C)}"); }
        }
        class D : A
        {
            public override void Process() { Console.WriteLine($"Inside: {nameof(D)}"); }
        }

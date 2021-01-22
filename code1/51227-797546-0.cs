    class A
    {
       public virtual void F() { }
    }
    class B : A
    {
       public sealed override void F() { }
    }
    class C : B
    {
       public override void F() { } // Compilation error - 'C.F()': cannot override 
                                    // inherited member 'B.F()' because it is sealed
    }

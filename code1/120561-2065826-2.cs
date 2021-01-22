    class base     { public virtual void  foo() { Console.write("base.foo"); } }
    class derived  { public override void foo() { Console.write("derived.foo"); } }
    base b = new base();
    b.foo()  // prints "base.foo" // no issue b is a base and variable is a base
    base b = new derived();
    b.foo(); // prints "derived.foo" because concrete tyoe is derived, not base
